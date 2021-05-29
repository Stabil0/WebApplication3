using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Emploeeys
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public DetailsModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
