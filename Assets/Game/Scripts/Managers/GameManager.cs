using System;
using Game.Scripts.Scene;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public bool levelFinishButtonActive;
        public bool isStartGame;
        public bool isFinishGame;
        public float gameTime;

        private bool _isClickEscape;

        private void Update()
        {
            ControlLevelFinishButton();
            ControlRestartButton();
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

        private void ControlRestartButton()
        {
            if (Input.GetKey(KeyCode.Escape) && !_isClickEscape)
            {
                _isClickEscape = true;
                var mainMenu = FindObjectOfType<MainMenu>();
                mainMenu.RestartGame();
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