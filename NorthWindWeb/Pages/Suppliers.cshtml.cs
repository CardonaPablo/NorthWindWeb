using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWindEntitiesLib;
using NorthwindContextLib;


namespace WebApplication1.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string> Suppliers { get; set; }
        private Northwind db;
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "NorthWind Website - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.CompanyName).ToArray();
        }
    }
}