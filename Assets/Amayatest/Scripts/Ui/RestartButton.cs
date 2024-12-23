using Amayatest.Scripts.Gameplay;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Amayatest.Scripts.Ui
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private float showDuration;

        public void Init(Game game)
        {
            game.gameFinishedEvent.AddListener(OnGameFinished);
            button.onClick.AddListener(game.Restart);
            transform.localScale = Vector3.zero;
        }

        private void OnGameFinished()
        {
            button.transform.DOScale(1, showDuration).SetEase(Ease.OutBounce);
        }
    }
}