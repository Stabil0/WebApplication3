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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public IndexModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        public IList<Orde> Orde { get;set; }

        public async Task OnGetAsync()
        {
            Orde = await _context.Ordes
                .Include(o => o.DishCodeNavigation)
                .Include(o => o.EmployeeCodeNavigation).ToListAsync();
        }
    }
}
