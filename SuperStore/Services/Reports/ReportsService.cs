﻿namespace SuperStore.Services.Reports
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using SuperStore.Data;
    using SuperStore.Data.Models;
    using SuperStore.Data.Models.Enums;
    using SuperStore.Services.Reports.Models;
    using System;
    using System.Linq;

    public class ReportsService : IReportsService
    {
        private readonly SuperStoreDbContext data;

        private readonly IConfigurationProvider mapper;

        public ReportsService(SuperStoreDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public void Add(string content,
            ReportType reportType,
            string productId,
            string userId)
        {

            var report = new Report
            {
                Content = content,
                ReportType = reportType,
                ProductId = productId,
                UserId = userId,
                PublishedOn = DateTime.UtcNow
            };

            this.data.Reports.Add(report);

            this.data.SaveChanges();

        }

        public ReportQueryModel All(
            string searchTerm = null,
            int currentPage = 1,
            int reportsPerPage = int.MaxValue,
            string productId = null)
        {
            var reportsQuery = this.data.Reports
               .AsQueryable();

            if (!string.IsNullOrEmpty(productId))
            {

                reportsQuery = reportsQuery.Where(x => x.ProductId == productId);

            }


            if (!string.IsNullOrEmpty(searchTerm))
            {

                reportsQuery = reportsQuery
                                         .Where(x =>
                                         x.Content.ToLower().Contains(searchTerm.ToLower()) ||
                                         x.ReportType.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                                         x.Product.Title.ToLower().Contains(searchTerm.ToLower()));

            }

            var totalReports = reportsQuery.Count();

            var reports = reportsQuery
                  .Skip((currentPage - 1) * reportsPerPage)
                    .Take(reportsPerPage)
                    .OrderByDescending(x => x.PublishedOn)
                    .ProjectTo<ReportServiceModel>(mapper)
                    .ToList();

            return new ReportQueryModel
            {
                Reports = reports,
                CurrentPage = currentPage,
                TotalReports = totalReports,
                ReportsPerPage = reportsPerPage,
            };

        }

        public bool Delete(int id)
        {
            var report = this.data.Reports.Find(id);

            if (report == null)
            {
                return false;
            }

            this.data.Reports.Remove(report);

            this.data.SaveChanges();

            return true;

        }

        public bool ReportExistsForProduct(string productId, string userId)
        => this.data.Reports.Any(x => x.ProductId == productId && x.UserId == x.UserId);
    }
}
