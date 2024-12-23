using Amayatest.Scripts.Gameplay;
using UnityEngine;

namespace Amayatest.Scripts.Ui
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TaskLabel taskLabel;
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private Fader fader;

        public void Init(Game game)
        {
            taskLabel.Init(game);
            fader.Init(game);
            restartButton.Init(game);
        }
    }
}