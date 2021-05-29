using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Emploeeys
{
    public class EditModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public EditModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Emploeey Emploeey { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Emploeey = await _context.Emploeeys
                .Include(e => e.PositionCodeNavigation).FirstOrDefaultAsync(m => m.EmployeeCode == id);

            if (Emploeey == null)
            {
                return NotFound();
            }
           ViewData["PositionCode"] = new SelectList(_context.Positions, "PositionCode", "JobTitle");
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

            _context.Attach(Emploeey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploeeyExists(Emploeey.EmployeeCode))
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

        private bool EmploeeyExists(long id)
        {
            return _context.Emploeeys.Any(e => e.EmployeeCode == id);
        }
    }
}
