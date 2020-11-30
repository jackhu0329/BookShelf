using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    private int score = 0;
    private int navigation = 0;
    private float timer;
    private bool timerBool = true, UI = true;
    public Text time;
    public Text scoreText;
    private int failCount = 0;
    private int count=0;
    private string[] t;
    // Start is called before the first frame update
    void Awake()
    {
        t = new string[5];
        t[0] = "12345";
        timer = 0;
        transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(false);
        GameEventCenter.AddEvent("GetScore", GetScore);
        GameEventCenter.AddEvent("MotionFailed", MotionFailed);
        GameEventCenter.AddEvent<int>("BookNumber", BookNumber);
        TimerStart();
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameEventCenter.DispatchEvent("SuccessHigh",1);
            GameEventCenter.DispatchEvent("SuccessMid", 2);
            GameEventCenter.DispatchEvent("SuccessLow", 3);
            //GameEventCenter.DispatchEvent("BookNumber",1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //GameEventCenter.DispatchEvent("BookNumber", 0);
            GameEventCenter.DispatchEvent("BookNumber", 1);
        }
        //test


        if (timerBool)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameEventCenter.DispatchEvent("SpawnCup");
            GameEventCenter.DispatchEvent("MotionFailed");
        }

        if (failCount == 3)
        {
            UI = false;
            TimerEnd();
            time.text = "花費時間:" + Mathf.FloorToInt(timer);
            transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(true);
        }

        if (count == 5)
        {
            UI = false;
            TimerEnd();
            time.text = "花費時間:" + Mathf.FloorToInt(timer);
            scoreText.text = "任務完成數: "+score;
            transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnGUI()
    {
        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(255, 255, 255);
        gameUI.fontSize = 60;

        if (UI)
        {
            GUI.Label(new Rect(Screen.width / 10 * 1, (Screen.height / 6 * 5), 200, 100),
            "已完成" + score + "次"
            , gameUI);
            /*GUI.Label(new Rect(Screen.width / 10 * 4, (Screen.height / 8 * 1), 200, 100),
            t[0]
            , gameUI);*/


            if (navigation == 1)
            {
                GUI.Label(new Rect(Screen.width / 10 * 4, (Screen.height / 6 * 1), 200, 100),
                "請將書本放到上層櫃子"
                , gameUI);
            }
            else if (navigation == 2)
            {
                GUI.Label(new Rect(Screen.width / 10 * 4, (Screen.height / 6 * 1), 200, 100),
                "請將書本放到中間櫃子"
                , gameUI);
            }
            else if (navigation == 3)
            {
                GUI.Label(new Rect(Screen.width / 10 * 4, (Screen.height / 6 * 1), 200, 100),
                "請將書本放到下層櫃子"
                , gameUI);
            }
            else
            {
                GUI.Label(new Rect(Screen.width / 10 * 4, (Screen.height / 6 * 1), 200, 100),
                "請拿起桌上書本"
                , gameUI);
            }


        }

    }

    public void GetScore()
    {
        score++;
        count++;
    }

    private void TimerStart()
    {
        timerBool = true;
    }

    private void TimerEnd()
    {
        if (timerBool)
        {
            timerBool = false;
        }

    }

    private void MotionFailed()
    {
        failCount++;
        count++;
        transform.GetComponent<Canvas>().transform.GetChild(failCount).gameObject.SetActive(true);
    }

    private void BookNumber(int n)
    {
        navigation = n;
    }


}
