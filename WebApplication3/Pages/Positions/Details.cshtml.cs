using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Positions
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public DetailsModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Positions.FirstOrDefaultAsync(m => m.PositionCode == id);

            if (Position == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
