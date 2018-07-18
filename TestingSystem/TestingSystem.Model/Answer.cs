﻿namespace TestingSystem.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isCorrect { get; set; }

        public int? QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
