﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class BookEntity : GameEntityBase
    {
        private ParticleSystem particleObj;
        private float timer;
        public int n;// 0:low 1:mid 2:high
        private int type;
        public void Awake()
        {
            float bias = Random.Range(-30, 30);
            n = Random.Range(0, 3);
            Debug.Log(n);
            InitParameter();
            //particleObj = gameObject.GetComponentInChildren<ParticleSystem>();
            //transform.eulerAngles = new Vector3(0, 0, 90+ bias);
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
            if (other.CompareTag("Hand"))
                transform.GetComponent<Rigidbody>().isKinematic = false;
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
            if(transform.gameObject.tag == "Finish"|| other.CompareTag("Hand"))
            {
               // Debug.Log("QQQ");
                return;
            }
            Debug.Log(other.name);
            timer += Time.deltaTime;
            if (timer >= GameDataManager.FlowData.time)
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
                GameEventCenter.DispatchEvent("SpawnBook");
                GameEventCenter.DispatchEvent("SuccessLow", type-1);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent<Vector3>("ParticleStart", transform.position);
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
                GameEventCenter.DispatchEvent("ResetHand");
                Destroy(this.gameObject);
                Debug.Log("check 1");
            }
            else if (n == 1 && obj == "mid")
            {
                GameEventCenter.DispatchEvent("SpawnBook");
                GameEventCenter.DispatchEvent("SuccessMid", type-1);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent<Vector3>("ParticleStart", transform.position);
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
                GameEventCenter.DispatchEvent("ResetHand");
                Destroy(this.gameObject);
                Debug.Log("check 2");
            }
            else if (n == 2 && obj == "high")
            {
                GameEventCenter.DispatchEvent("SpawnBook");
                GameEventCenter.DispatchEvent("SuccessHigh", type-1);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent<Vector3>("ParticleStart", transform.position);
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
                GameEventCenter.DispatchEvent("ResetHand");
                Destroy(this.gameObject);
                Debug.Log("check 3");
            }
            else
            {
                Debug.Log("check fail");
                GameEventCenter.DispatchEvent("SpawnBook");
                GameEventCenter.DispatchEvent("ResetHand");
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.fail);
                Destroy(this.gameObject);
                GameEventCenter.DispatchEvent("MotionFailed");
            }

        }

        private void setBook()
        {

        }

        private void InitParameter()
        {
            Debug.Log(this.gameObject.name);
            switch (this.gameObject.name)
            {
                case "book1(Clone)":
                    type = 1;
                    break;
                case "book2(Clone)":
                    type = 2;
                    break;
                case "book3(Clone)":
                    type = 3;
                    break;
                case "book4(Clone)":
                    type = 4;
                    break;
            }
        }

    }
}


