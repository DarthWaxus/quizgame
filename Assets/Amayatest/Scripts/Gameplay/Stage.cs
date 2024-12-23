using System.Collections.Generic;
using Amayatest.Scripts.Classes;
using Amayatest.Scripts.ScriptableObjects;
using UnityEngine;

namespace Amayatest.Scripts.Gameplay
{
    public class Stage : MonoBehaviour
    {
        private QuizGenerator _quizGenerator;
        [SerializeField] private CardGrid cardGrid;
        private List<Question> _questions;

        private int _currentLevelId = 0;
        private int _levelsCount;
        private Game _game;
        private QuizConfig _quizConfig;
        private GameConfig _gameConfig;

        public void Init(Game game, QuizConfig quizConfig, GameConfig gameConfig)
        {
            _game = game;
            _quizConfig = quizConfig;
            _gameConfig = gameConfig;
            _game.cardSelectedEvent.AddListener(OnCardSelected);

            _quizGenerator = new QuizGenerator();
            _questions = _quizGenerator.GenerateQuiz(_quizConfig);

            cardGrid.Init(_game, gameConfig.cardBackgroundColors);
            LoadLevel(_currentLevelId);
        }

        public int GetCurrentLevelId()
        {
            return _currentLevelId;
        }

        private void OnCardSelected(Card card, bool correct)
        {
            if (correct)
            {
                _game.levelCompletedEvent.Invoke();
                ChangeLevel();
            }
        }

        private void ChangeLevel()
        {
            if (_currentLevelId < _quizConfig.levels.Count - 1)
            {
                LoadLevel(++_currentLevelId);
            }
            else
            {
                _game.gameFinishedEvent.Invoke();
            }
        }

        private void LoadLevel(int levelId)
        {
            cardGrid.UpdateGridSize(_quizConfig.levels[levelId].size, _gameConfig.cardCellPrefab);
            cardGrid.CenterGrid();
            cardGrid.AssignCardConfigsToCards(_questions[levelId], levelId == 0);
            _game.levelLoadedEvent.Invoke(this);
        }

        public string GetCurrentLevelTaskMessage()
        {
            return "Find " + _questions[_currentLevelId].Answers[_questions[_currentLevelId].CorrectAnswerId].questionValue;
        }
    }
}