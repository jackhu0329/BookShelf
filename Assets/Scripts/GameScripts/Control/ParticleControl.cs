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
            GameEventCenter.AddEvent<Vector3>("ParticleStart", ParticleStart);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // GameObject.Instantiate(FloatingText, transform.position, Quaternion.identity);
                Debug.Log("particleObj QQQQ");
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
                particleObj.Play();
            }
        }

        private void ParticleStart(Vector3 v)
        {
            objPosition = GameObject.Find("Wipe_1").transform.position;

            transform.position = new Vector3(v.x, v.y, v.z);
            //GameObject.Instantiate(FloatingText, transform.position, Quaternion.identity);
            particleObj.Play();
        }
    }
}

