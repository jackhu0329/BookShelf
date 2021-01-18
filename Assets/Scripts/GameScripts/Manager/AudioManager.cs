using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public enum AudioSelect
    {
        Success, fail, EndAudio, BGM, GetScore
    }
    public class AudioManager : MonoBehaviour
    {
        public AudioClip S1,S2,S3;
        public AudioClip fail;
        public AudioClip EndAudio;
        public AudioClip BGM;
        public AudioClip GetScore;
        private bool gameOver = false;
        // Start is called before the first frame update
        void Awake()
        {
            GameEventCenter.AddEvent<AudioSelect>("PlayAudio", PlayAudio);
            GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.BGM);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.Success);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.EndAudio);
            }
        }

        public void PlayAudio(AudioSelect s)
        {
            switch (s)
            {
                //case AudioSelect.Success: GameAudioController.Instance.PlayOneShot(Success); break;
                case AudioSelect.fail: GameAudioController.Instance.PlayOneShot(fail); break;
                case AudioSelect.EndAudio: GameOver(); break;
                case AudioSelect.BGM: GameAudioController.Instance.LoopPlay(BGM); break;
                case AudioSelect.GetScore: Success(); break;
            }
        }

        private void GameOver()
        {
            if (!gameOver)
            {
                GameAudioController.Instance.LoopPlay(EndAudio);
                gameOver = true;
            }
        }

        private void Success()
        {
            GameAudioController.Instance.PlayOneShot(GetScore);
            int x = Random.Range(0, 3);
            switch (x){
                case 0: GameAudioController.Instance.PlayOneShot(S1);break;
                case 1: GameAudioController.Instance.PlayOneShot(S2); break;
                case 2: GameAudioController.Instance.PlayOneShot(S3); break;
            }
            
        }
    }
}


