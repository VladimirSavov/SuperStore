﻿namespace SuperStore.Areas.Admin.Controllers
{
    using SuperStore.Areas.Admin.Models.Reports;
    using SuperStore.Services.Reports;
    using Microsoft.AspNetCore.Mvc;

    public class ReportsController:AdminController
    {
        private readonly IReportsService reports;

        public ReportsController(IReportsService reports)
        {
            this.reports = reports;
        }

        public IActionResult All([FromQuery] ReportsQueryModel query)
        {
            var queryResult = this.reports.All(
             query.SearchTerm,
             query.CurrentPage,
             ReportsQueryModel.ReportsPerPage);

             query.Reports = queryResult.Reports;
             query.TotalReports = queryResult.TotalReports;

            return this.View(query);
        }

        public IActionResult Delete(int id)
        {
            var isDeleted = this.reports.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            this.TempData[WebConstants.GlobalMessageKey] = "Comment was deleted successfully!";

            return RedirectToAction(nameof(All));
        }
    }
}
