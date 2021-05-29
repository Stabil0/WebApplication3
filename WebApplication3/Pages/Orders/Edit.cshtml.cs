using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public EditModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Orde Orde { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Orde = await _context.Ordes
                .Include(o => o.DishCodeNavigation)
                .Include(o => o.EmployeeCodeNavigation).FirstOrDefaultAsync(m => m.CustomerName == id);

            if (Orde == null)
            {
                return NotFound();
            }
           ViewData["DishCode"] = new SelectList(_context.Menus, "DishCode", "DishName");
           ViewData["EmployeeCode"] = new SelectList(_context.Emploeeys, "EmployeeCode", "Adress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Orde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdeExists(Orde.CustomerName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrdeExists(string id)
        {
            return _context.Ordes.Any(e => e.CustomerName == id);
        }
    }
}
