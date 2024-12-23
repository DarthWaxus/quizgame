using Amayatest.Scripts.Gameplay;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Amayatest.Scripts.Ui
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float fadeInDuration;
        [SerializeField] private float fadeInAlpha = 0.8f;

        public void Init(Game game)
        {
            game.gameFinishedEvent.AddListener(OnGameFinished);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }

        private void OnGameFinished()
        {
            image.DOFade(fadeInAlpha, fadeInDuration).SetEase(Ease.OutSine);
        }
    }
}