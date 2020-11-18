using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class BookEntity : GameEntityBase
    {
        private ParticleSystem particleObj;
        public void Awake()
        {
            //particleObj = gameObject.GetComponentInChildren<ParticleSystem>();
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
            if (other.CompareTag("Hand"))
            {
                return;
            }

            //Debug.Log(other.name);
            if (other.name == "TrashbinGreen")
            {
                Destroy(this.gameObject);
            }
            else
            {

                Destroy(this.gameObject);
            }
            Destroy(this.gameObject);
        }

        public void OnTriggerExit(Collider other)
        {

        }

        public void OnTriggerStay(Collider other)
        {


        }

        private void Throw()
        {


        }

    }
}


