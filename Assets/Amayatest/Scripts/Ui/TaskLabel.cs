using System;
using Amayatest.Scripts.Gameplay;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Amayatest.Scripts.Ui
{
    public class TaskLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private float fadeInDuration = 1;

        private void Awake()
        {
            label.color = new Color(label.color.r, label.color.g, label.color.b, 0);
        }

        public void Init(Game game)
        {
            game.levelLoadedEvent.AddListener(OnLevelLoaded);
        }

        private void OnLevelLoaded(Stage stage)
        {
            label.gameObject.SetActive(true);
            label.text = stage.GetCurrentLevelTaskMessage();
            if (stage.GetCurrentLevelId() == 0)
            {
                label.DOFade(1, fadeInDuration);
            }
        }
    }
}