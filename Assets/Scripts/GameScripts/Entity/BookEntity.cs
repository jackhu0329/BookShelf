using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class BookEntity : GameEntityBase
    {
        private ParticleSystem particleObj;
        private float timer;
        private int n;// 0:mid 1:high
        public void Awake()
        {
            float bias = Random.Range(0, 30);
            n = Random.Range(0, 2);
            Debug.Log(n);
            //particleObj = gameObject.GetComponentInChildren<ParticleSystem>();
            transform.eulerAngles = new Vector3(0, 0, 90+ bias);
            //Debug.Log("gravity");
            Physics.gravity = new Vector3(0, -20, 0);
        }
        public override void EntityDispose()
        {

        }

        public void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            timer = 0;
            //Debug.Log(other.name);
            /*if (other.CompareTag("Hand"))
            {
                return;
            }

            //Debug.Log(other.name);
            if (other.name == "TrashbinGreen")
            {
                //Destroy(this.gameObject);
            }
            else
            {

                //Destroy(this.gameObject);
            }*/
            //Destroy(this.gameObject);
        }

        public void OnTriggerExit(Collider other)
        {
            timer = 0;
        }

        public void OnTriggerStay(Collider other)
        {
            Debug.Log(other.name);
            timer += Time.deltaTime;
            if (timer > 2)
            {
                Debug.Log("timer trigger!!!!!!!!");
                CheckStatus(other.name);
            }
            //Debug.Log(timer);

        }

        private void CheckStatus(string obj)
        {
            Debug.Log("CheckStatus:" + obj);
            if (n==0&&obj=="low")
            {
                GameEventCenter.DispatchEvent("GetScore");
                Destroy(this);
                Debug.Log("check 1");
            }
            else if (n == 1 && obj == "high")
            {
                GameEventCenter.DispatchEvent("GetScore");
                Destroy(this);
                Debug.Log("check 2");
            }
            else
            {
                Debug.Log("check fail");
                Destroy(this);
                GameEventCenter.DispatchEvent("MotionFailed");
            }

        }

    }
}


