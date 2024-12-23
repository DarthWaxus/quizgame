using System.Collections.Generic;
using Amayatest.Scripts.ScriptableObjects;
using UnityEngine;

namespace Amayatest.Scripts.Classes
{
    public class QuizGenerator
    {
        public List<Question> GenerateQuiz(QuizConfig quizConfig)
        {
            List<Question> questions = new List<Question>();
            List<List<CardConfig>> bundles = new List<List<CardConfig>>();
            List<int> lastBundleCardIdUsed = new List<int>();
            quizConfig.cardBundleConfigs.ForEach(cardBundleConfig =>
            {
                List<CardConfig> cards = new List<CardConfig>(cardBundleConfig.cards.ToArray());
                cards.ShuffleList();
                bundles.Add(cards);
                lastBundleCardIdUsed.Add(0);
            });
            int cardBundleConfigsCount = bundles.Count;
            quizConfig.levels.ForEach((levelConfig) =>
            {
                Question question = new Question();
                int bundleId = Random.Range(0, cardBundleConfigsCount);
                CardConfig correctCardConfig = bundles[bundleId][lastBundleCardIdUsed[bundleId]];
                List<CardConfig> notCorrectCardConfigs =
                    new List<CardConfig>(bundles[bundleId].FindAll(config => config != correctCardConfig));
                notCorrectCardConfigs.ShuffleList();
                int questionsCount = levelConfig.size.x * levelConfig.size.y;
                question.Answers.Add(correctCardConfig);
                question.Answers.AddRange(notCorrectCardConfigs.GetRange(0, questionsCount - 1));
                question.Answers.ShuffleList();
                question.CorrectAnswerId = question.Answers.FindIndex(config => config == correctCardConfig);
                questions.Add(question);
                lastBundleCardIdUsed[bundleId]++;
                if (lastBundleCardIdUsed[bundleId] >= bundles[bundleId].Count)
                {
                    lastBundleCardIdUsed[bundleId] = 0;
                }
            });
            return questions;
        }
    }
}