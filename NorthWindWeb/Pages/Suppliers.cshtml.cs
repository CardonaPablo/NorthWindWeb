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
        public IList<string> Suppliers { get; set; }
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Suppliers.Add(Supplier);
            await db.SaveChangesAsync();

            return RedirectToPage("./suppliers");
        }
    }
}