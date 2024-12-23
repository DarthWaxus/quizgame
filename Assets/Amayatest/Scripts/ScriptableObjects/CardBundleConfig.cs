using System.Collections.Generic;
using UnityEngine;

namespace Amayatest.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CardBundleConfig", menuName = "CardBundleConfig", order = 0)]
    public class CardBundleConfig : ScriptableObject
    {
        public List<CardConfig> cards;
    }
}