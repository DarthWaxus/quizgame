using UnityEngine;

namespace Amayatest.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CardConfig", menuName = "CardConfig", order = 0)]
    public class CardConfig : ScriptableObject
    {
        public string questionValue;
        public Sprite iconSprite;
        public float rotation;
    }
}