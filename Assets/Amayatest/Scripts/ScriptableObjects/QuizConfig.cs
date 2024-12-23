using System.Collections.Generic;
using UnityEngine;

namespace Amayatest.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "QuizConfig", menuName = "QuizConfig", order = 0)]
    public class QuizConfig : ScriptableObject
    {
        public List<LevelConfig> levels;
        public List<CardBundleConfig> cardBundleConfigs;
    }
}