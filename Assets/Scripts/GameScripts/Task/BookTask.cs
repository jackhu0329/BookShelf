using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace GameFrame
{
    public class BookTask : TaskBase
    {
        private GameObject objCup, objBottle, objPaper;


        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit start");
            GameEventCenter.AddEvent("SpawnCup", SpawnBook);

            //objCup = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cup.gameObject;

            SpawnBook();

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
            //GameObject.Instantiate(objCup, objCup.transform.position, Quaternion.identity);
        }




    }
}


