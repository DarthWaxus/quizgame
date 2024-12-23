using System.Collections.Generic;
using Amayatest.Scripts.ScriptableObjects;
using DG.Tweening;
using UnityEngine;

namespace Amayatest.Scripts.Gameplay
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer icon;
        [SerializeField] private SpriteRenderer background;

        [SerializeField] private float wrongAnswerShakeShift;
        [SerializeField] private float wrongAnswerShakeDuration;

        [SerializeField] private float correctAnswerShakeShift;
        [SerializeField] private float correctAnswerShakeDuration;

        [SerializeField] private float startAnimationDuration;
        [SerializeField] private float startAnimationMaxDelay;
        [SerializeField] private GameObject correctFxPrefab;
        private bool _interactable = false;

        private int _answerId;
        private bool _isCorrect;
        private Tween _currentIconTween;
        private Vector3 _startIconLocalPosition;
        private Game _game;
        private List<Color> _backgroundColors;

        private void Start()
        {
            _startIconLocalPosition = icon.transform.localPosition;
        }

        public void Init(Game game, List<Color> backgroundColors)
        {
            _game = game;
            _backgroundColors = backgroundColors;
            _game.levelCompletedEvent.AddListener(() => SetInteractable(false));
        }

        public void SetInteractable(bool interactable)
        {
            _interactable = interactable;
        }

        public void Assign(int answerId, bool isCorrect, CardConfig cardConfig, bool playStartAnimation = false)
        {
            ResetIconTween();
            _answerId = answerId;
            _isCorrect = isCorrect;
            icon.sprite = cardConfig.iconSprite;
            icon.transform.localRotation = Quaternion.Euler(0, 0, cardConfig.rotation);
            if (_backgroundColors != null && _backgroundColors.Count > 0)
            {
                background.color = _backgroundColors[Random.Range(0, _backgroundColors.Count)];
            }

            if (playStartAnimation)
            {
                PlayStartAnimation();
            }
            else
            {
                SetInteractable(true);
            }
        }

        private void OnMouseDown()
        {
            if (!_interactable)
            {
                return;
            }

            if (_isCorrect)
            {
                SetInteractable(false);
                CorrectAnswerShake();
            }
            else
            {
                WrongAnswerShake();
            }
        }

        private void PlayStartAnimation()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, startAnimationDuration)
                .SetEase(Ease.OutBounce)
                .SetDelay(Random.Range(0, startAnimationMaxDelay))
                .OnComplete(()=>SetInteractable(true));
        }

        private void CorrectAnswerShake()
        {
            ResetIconTween();
            Instantiate(correctFxPrefab, transform.position, Quaternion.identity);
            icon.transform.DOPunchScale(Vector3.one * correctAnswerShakeShift, correctAnswerShakeDuration)
                .OnComplete(() => _game.cardSelectedEvent.Invoke(this, true));
        }

        private void WrongAnswerShake()
        {
            ResetIconTween();
            _currentIconTween = icon.transform
                .DOPunchPosition(Vector3.right * wrongAnswerShakeShift, wrongAnswerShakeDuration)
                .OnComplete(() => _game.cardSelectedEvent.Invoke(this, false));
        }

        private void ResetIconTween()
        {
            if (_currentIconTween != null && _currentIconTween.active && !_currentIconTween.IsComplete())
            {
                _currentIconTween.Kill();
                icon.transform.localPosition = _startIconLocalPosition;
            }
        }
    }
}