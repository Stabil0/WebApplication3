using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public DetailsModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menus
                .Include(m => m.IngredientCodeNavigation).FirstOrDefaultAsync(m => m.DishCode == id);

            if (Menu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
