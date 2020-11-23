using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace GameFrame
{
    public class BookTask : TaskBase
    {
        private GameObject objBook1, objBook2, objBook3, objBook4;


        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit start");
            GameEventCenter.AddEvent("SpawnCup", SpawnBook);

            //objCup = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cup.gameObject;
            objBook1 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book1.gameObject;
            objBook2 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book2.gameObject;
            objBook3 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book3.gameObject;
            objBook4 = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Book4.gameObject;

            //SpawnBook();
            InitBook();

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
            Vector3 p = new Vector3(objBook1.transform.position.x+15f, objBook1.transform.position.y-10f, objBook1.transform.position.z - 5f);
            GameObject.Instantiate(objBook1, p, Quaternion.identity);
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




    }
}


