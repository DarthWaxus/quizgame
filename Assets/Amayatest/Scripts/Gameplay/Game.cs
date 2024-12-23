using System.Collections;
using System.Collections.Generic;
using Amayatest.Scripts.Classes;
using Amayatest.Scripts.ScriptableObjects;
using Amayatest.Scripts.Ui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Amayatest.Scripts.Gameplay
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private QuizConfig quizConfig;
        [SerializeField] private GameConfig gameConfig;
        private UiManager _ui;
        private Stage _stage;

        public UnityEvent<Card,bool> cardSelectedEvent = new UnityEvent<Card,bool>();
        public UnityEvent levelCompletedEvent = new UnityEvent();
        public UnityEvent<Stage> levelLoadedEvent = new UnityEvent<Stage>();
        public UnityEvent gameFinishedEvent = new UnityEvent();

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void Start()
        {
            StartCoroutine(StartGameRoutine());
        }

        private IEnumerator StartGameRoutine()
        {
            _stage = Instantiate(gameConfig.stagePrefab).GetComponent<Stage>();
            _ui = Instantiate(gameConfig.uiPrefab).GetComponent<UiManager>();
            _ui.Init(this);
            
            yield return new WaitForSeconds(gameConfig.startDelay);

            _stage.Init(this, quizConfig, gameConfig);
        }
    }
}