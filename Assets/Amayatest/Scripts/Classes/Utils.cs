using System.Collections.Generic;

namespace Amayatest.Scripts.Classes
{
    public static class Utils
    {
        private static System.Random _rng = new System.Random();
        public static void ShuffleList<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            };
        }
    }
}