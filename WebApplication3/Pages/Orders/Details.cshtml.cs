using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public DetailsModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
