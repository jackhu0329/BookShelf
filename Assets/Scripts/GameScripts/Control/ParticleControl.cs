using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameFrame
{
    public class ParticleControl : MonoBehaviour
    {
        private ParticleSystem particleObj;
        private GameObject FloatingText;
        private Vector3 objPosition;
        // Start is called before the first frame update
        void Start()
        {
            //FloatingText = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().FloatingText.gameObject;
            particleObj = gameObject.GetComponentInChildren<ParticleSystem>();
            GameEventCenter.AddEvent("ParticleStart", ParticleStart);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
               // GameObject.Instantiate(FloatingText, transform.position, Quaternion.identity);
                Debug.Log("particleObj2");
                particleObj.Play();
            }
        }

        private void ParticleStart()
        {
            objPosition = GameObject.Find("CupRegular(Clone)").transform.position;
            transform.position = objPosition;
            //GameObject.Instantiate(FloatingText, transform.position, Quaternion.identity);
            particleObj.Play();
        }
    }
}

