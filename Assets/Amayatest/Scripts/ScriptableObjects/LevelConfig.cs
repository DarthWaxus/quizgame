using UnityEngine;

namespace Amayatest.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public Vector2Int size;
    }
}