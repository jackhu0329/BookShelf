using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace GameFrame
{
    public class BookTask : TaskBase
    {
        private GameObject objBook1, objBook2, objBook3, objBook4,shelf;

        private float high,mid,low;


        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit start");
            GameEventCenter.AddEvent("SpawnBook", SpawnBook);
            GameEventCenter.AddEvent<int>("SuccessHigh", SuccessHigh);
            GameEventCenter.AddEvent<int>("SuccessMid", SuccessMid);
            GameEventCenter.AddEvent<int>("SuccessLow", SuccessLow);
            //objCup = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cup.gameObject;
            objBook1 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book1.gameObject;
            objBook2 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book2.gameObject;
            objBook3 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book3.gameObject;
            objBook4 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book4.gameObject;
            shelf = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Shelf.gameObject;
            SpawnBook();
            //SpawnBook();
            //InitBook();

            yield return null;
        }

        //public void 
        public override IEnumerator TaskStart()
        {


            yield return null;
        }


        public override IEnumerator TaskStop()
        {
            yield return null;
        }

        public void SpawnBook()
        {
            Vector3 p = new Vector3(objBook1.transform.position.x+5f, objBook1.transform.position.y-12.4f, objBook1.transform.position.z + 20f);
            GameObject obj ;


            int n = Random.Range(0, 4);
            //Debug.Log(n);
            switch (n)
            {
                case 0:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
                case 1:
                    obj = GameObject.Instantiate(objBook2, p, Quaternion.identity);
                    break;
                case 2:
                    obj = GameObject.Instantiate(objBook3, p, Quaternion.identity);
                    break;
                case 3:
                    obj = GameObject.Instantiate(objBook4, p, Quaternion.identity);
                    break;
                default:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
            }


            obj.GetComponent<Rigidbody>().isKinematic = true;
        }

        public void InitBook()
        {
            for(int x = 0; x < 5; x++)
            {
                Vector3 p = new Vector3(objBook1.transform.position.x + 15f-x*4, objBook1.transform.position.y - 10f, objBook1.transform.position.z - 5f);


                int n = Random.Range(0, 4);
                //Debug.Log(n);
                switch (n)
                {
                    case 0:
                        GameObject.Instantiate(objBook1, p, Quaternion.identity);
                        break;
                    case 1:
                        GameObject.Instantiate(objBook2, p, Quaternion.identity);
                        break;
                    case 2:
                        GameObject.Instantiate(objBook3, p, Quaternion.identity);
                        break;
                    case 3:
                        GameObject.Instantiate(objBook4, p, Quaternion.identity);
                        break;
                }
                //GameObject.Instantiate(objBook1, p, Quaternion.identity);
            }
            

        }

        private void SuccessLow(int n)
        {
            GameObject obj;
            Vector3 p = new Vector3(objBook1.transform.position.x + 18f- low, objBook1.transform.position.y - 14.4f, objBook1.transform.position.z - 5f);


            switch (n)
            {
                case 1:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
                case 2:
                    obj = GameObject.Instantiate(objBook2, p, Quaternion.identity);
                    break;
                case 3:
                    obj = GameObject.Instantiate(objBook3, p, Quaternion.identity);
                    break;
                case 4:
                    obj = GameObject.Instantiate(objBook4, p, Quaternion.identity);
                    break;
                default:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
            }


            obj.transform.eulerAngles = new Vector3(0, 0, 90);
            obj.tag = "Finish";
            obj.GetComponent<Rigidbody>().isKinematic = true;
            low += 2.2f;
        }

        private void SuccessMid(int n)
        {
            GameObject obj;
            Vector3 p = new Vector3(objBook1.transform.position.x + 18f - mid, objBook1.transform.position.y - 3.4f, objBook1.transform.position.z - 5f);


            switch (n)
            {
                case 0:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
                case 1:
                    obj = GameObject.Instantiate(objBook2, p, Quaternion.identity);
                    break;
                case 2:
                    obj = GameObject.Instantiate(objBook3, p, Quaternion.identity);
                    break;
                case 3:
                    obj = GameObject.Instantiate(objBook4, p, Quaternion.identity);
                    break;
                default:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
            }


            obj.transform.eulerAngles = new Vector3(0, 0, 90);
            obj.tag = "Finish";
            obj.GetComponent<Rigidbody>().isKinematic = true;
            mid += 2.2f;
        }


        private void SuccessHigh(int n)
        {
            GameObject obj;
            Vector3 p = new Vector3(objBook1.transform.position.x + 18f - high, objBook1.transform.position.y + 5.8f, objBook1.transform.position.z - 5f);


            switch (n)
            {
                case 0:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
                case 1:
                    obj = GameObject.Instantiate(objBook2, p, Quaternion.identity);
                    break;
                case 2:
                    obj = GameObject.Instantiate(objBook3, p, Quaternion.identity);
                    break;
                case 3:
                    obj = GameObject.Instantiate(objBook4, p, Quaternion.identity);
                    break;
                default:
                    obj = GameObject.Instantiate(objBook1, p, Quaternion.identity);
                    break;
            }


            obj.transform.eulerAngles = new Vector3(0, 0, 90);
            obj.tag = "Finish";
            obj.GetComponent<Rigidbody>().isKinematic = true;
            high += 2.2f;
        }


    }
}


