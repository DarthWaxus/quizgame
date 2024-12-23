using System.Collections.Generic;
using UnityEngine;

namespace Amayatest.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public GameObject cardCellPrefab;
        public float startDelay = 1;
        public GameObject uiPrefab;
        public GameObject stagePrefab;
        public List<Color> cardBackgroundColors;
    }
}