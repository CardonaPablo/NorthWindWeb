using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWindEntitiesLib;
using NorthwindContextLib;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string> Suppliers { get; set; }
        private Northwind db;
        [BindProperty] public Supplier Supplier { get; set; }
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "NorthWind Website - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.CompanyName).ToArray();
        }

        [HttpPost]
        public IActionResult onPost()
        {
            try
            {
            if (ModelState.IsValid)
                {
                    db.Suppliers.Add(Supplier);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return RedirectToPage("/suppliers");
        }
    }
}