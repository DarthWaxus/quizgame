using System.Collections.Generic;
using Amayatest.Scripts.ScriptableObjects;

namespace Amayatest.Scripts.Classes
{
    public class Question
    {
        public int CorrectAnswerId;
        public List<CardConfig> Answers = new List<CardConfig>();
    }
}