using System.Collections.Generic;
using Amayatest.Scripts.Classes;
using Amayatest.Scripts.ScriptableObjects;
using UnityEngine;

namespace Amayatest.Scripts.Gameplay
{
    public class CardGrid : MonoBehaviour
    {
        private List<List<Card>> _grid = new List<List<Card>>();
        private List<Card> _cards = new List<Card>();
        private List<Color> _cardBackgroundColors;
        private Vector2Int _size;
        private Game _game;

        public void Init(Game game, List<Color> colors)
        {
            _game = game;
            _cardBackgroundColors = colors;
        }
        public void UpdateGridSize(Vector2Int size, GameObject cardTilePrefab)
        {
            _size = size;
            for (int y = 0; y < size.y; y++)
            {
                if (_grid.Count <= y)
                {
                    _grid.Add(new List<Card>());
                }

                for (int x = 0; x < size.x; x++)
                {
                    if (_grid[y].Count <= x)
                    {
                        Card card = Instantiate(cardTilePrefab, transform).GetComponent<Card>();
                        card.transform.localPosition = new Vector3(x, y, 0);
                        card.Init(_game, _cardBackgroundColors);
                        _grid[y].Add(card);
                        _cards.Add(card);
                    }
                }
            }
        }

        public void AssignCardConfigsToCards(Question question, bool playStartAnimation=false)
        {
            int cardsCount = _cards.Count;
            int answersCount = question.Answers.Count;
            for (int i = 0; i < answersCount; i++)
            {
                if (i >= cardsCount)
                {
                    Debug.LogError("bad cards amount");
                    break;
                }

                _cards[i].Assign(i, i == question.CorrectAnswerId, question.Answers[i], playStartAnimation);
            }
        }

        public void CenterGrid()
        {
            transform.position = new Vector3(-_size.x/2,-_size.y/2, 0);
        }
    }
}