﻿namespace SuperStore.Services.Answers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using SuperStore.Data;
    using SuperStore.Data.Models;
    using SuperStore.Services.Answers.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AnswerService : IAnswerService
    {
        private readonly SuperStoreDbContext data;

        private readonly IConfigurationProvider mapper;

        public AnswerService(SuperStoreDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public void Create(
            int questionId,
            string userId,
            string content,
            bool IsPublic = false)
        {

            var answer = new Answer
            {
                QuestionId = questionId,
                UserId = userId,
                Content = content,
                PublishedOn = DateTime.UtcNow,
                IsPublic = IsPublic
            };

            this.data.Answers.Add(answer);

            this.data.SaveChanges();

        }

        public IEnumerable<AnswerServiceModel> AnswersOfQuestion(int questionId)
        => this.data.Answers.Where(x => x.QuestionId == questionId && x.IsPublic)
            .OrderBy(x => x.PublishedOn)
            .ProjectTo<AnswerServiceModel>(mapper)
            .ToList();

        public void ChangeVisibility(int id)
        {
            var answer = this.data.Answers.Find(id);

            if (answer == null)
            {
                return;
            }

            answer.IsPublic = !answer.IsPublic;

            this.data.SaveChanges();
        }

        public bool Delete(int id)
        {
            var answer = this.data.Answers.Find(id);

            if (answer == null)
            {
                return false;
            }

            this.data.Answers.Remove(answer);

            this.data.SaveChanges();

            return true;
        }

        public AnswerQueryModel All(
            string searchTerm = null,
            int currentPage = 1,
            int answersPerPage = int.MaxValue,
            bool IsPublicOnly = true)
        {
            var answersQuery = this.data.Answers
                .Where(x => !IsPublicOnly || x.IsPublic)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {

                answersQuery = answersQuery
                                         .Where(x =>
                                         x.Content.ToLower().Contains(searchTerm.ToLower()));

            }

            var totalAnswers = answersQuery.Count();

            var answers = answersQuery
                  .Skip((currentPage - 1) * answersPerPage)
                    .Take(answersPerPage)
                    .OrderByDescending(x => x.PublishedOn)
                    .ProjectTo<AnswerServiceModel>(mapper)
                    .ToList();

            return new AnswerQueryModel
            {
                Answers = answers,
                CurrentPage = currentPage,
                TotalAnswers = totalAnswers,
                AnswersPerPage = answersPerPage,
            };
        }
    }
}
