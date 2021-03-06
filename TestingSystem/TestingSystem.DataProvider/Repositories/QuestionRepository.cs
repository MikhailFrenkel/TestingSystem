﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private ApplicationDbContext db;

        public QuestionRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public void Create(Question item)
        {
            db.Questions.Add(item);
        }

        public void Delete(int id)
        {
            Question item = db.Questions.Find(id);
            if (item != null)
            {
                db.Answers.RemoveRange(item.Answers);
                db.Questions.Remove(item);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions.ToList();
        }

        public Question GetById(int id)
        {
            return db.Questions.Find(id);
        }

        public void Update(Question item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
