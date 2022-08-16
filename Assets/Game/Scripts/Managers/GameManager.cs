using System;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public bool levelFinishButtonActive;

        public bool isStartGame;
        public bool isFinishGame;
        public float gameTime;

        private void Update()
        {
            ControlLevelFinishButton();
            if (isStartGame)
            {
                gameTime += Time.deltaTime;
            }
        }

        private void ControlLevelFinishButton()
        {
            if (Input.GetKey(KeyCode.F))
            {
                levelFinishButtonActive = true;
            }
            else
            {
                levelFinishButtonActive = false;
            }
        }

        public void StartGame()
        {
            isStartGame = true;
        }

        public void FinishGame()
        {
            isFinishGame = true;
        }
    }
}