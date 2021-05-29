using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Warehouses
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public DetailsModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        public Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehouse = await _context.Warehouses.FirstOrDefaultAsync(m => m.IngredientCode == id);

            if (Warehouse == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
