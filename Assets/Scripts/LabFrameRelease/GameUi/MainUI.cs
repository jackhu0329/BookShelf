using System.Collections;
using System.Collections.Generic;
using GameData;
using LabData;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject launcher;
    public GameObject editor;
    public Button startButton;
    public Button settingButton;
    public InputField scriptName;

    public Button settingFinishButton;
    public Dropdown time;
    public Dropdown count;
    private int timev, countv;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameSceneManager.Instance.Change2MainScene();
        }
    }
    private void Start()
    {
        
        startButton.onClick.AddListener(StartButtonClick);
        settingButton.onClick.AddListener(SettingButtonClick);
        settingFinishButton.onClick.AddListener(FinishButtonClick);
    }

    public void StartButtonClick()
    {
        //MyGameData data = LabTools.GetData<MyGameData>(choose.captionText.text);
        GameFlowData gameFlow = new GameFlowData();
        // Debug.Log(data.angle);
        GameDataManager.FlowData = gameFlow;
        // GameDataManager.FlowData = new GameFlowData("01", data);

        GameDataManager.FlowData.time = timev;
        GameDataManager.FlowData.count = countv;

        //var Id = gameFlow.UserId;

        //GameDataManager.LabDataManager.LabDataCollectInit(() => Id);
        GameSceneManager.Instance.Change2MainScene();
        //Application.Quit();
    }

    public void SettingButtonClick()
    {
        launcher.SetActive(false);
        editor.SetActive(true);

    }

    public void FinishButtonClick()
    {
        timev = time.value+1; 
        countv = (count.value+1)*5;

        Debug.Log(timev + " " + countv);
        launcher.SetActive(true);
        editor.SetActive(false);

    }

}
