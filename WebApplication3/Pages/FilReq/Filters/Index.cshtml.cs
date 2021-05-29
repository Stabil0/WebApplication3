using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;


namespace WebApplication3.Pages.FilReq.Request
{
    public class IndexModel1 : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public IndexModel1(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }
        
        public IList<Emploeey> Emploeey { get; set; }

        public Position Position { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = _context.Positions.First(m => m.PositionCode == id);

            if (Position == null)
            {
                return NotFound();
            }
            Emploeey = await _context.Emploeeys
                .Include(e => e.PositionCode).Where(m => m.PositionCode == Position.PositionCode).ToListAsync();
            return Page();
        }
    }
   }
