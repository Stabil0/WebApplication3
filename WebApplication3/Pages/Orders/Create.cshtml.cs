using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Models;

namespace WebApplication3.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public CreateModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DishCode"] = new SelectList(_context.Menus, "DishCode", "DishName");
        ViewData["EmployeeCode"] = new SelectList(_context.Emploeeys, "EmployeeCode", "Adress");
            return Page();
        }

        [BindProperty]
        public Orde Orde { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ordes.Add(Orde);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
