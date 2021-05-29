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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Models.restoranContext _context;

        public IndexModel(WebApplication3.Models.restoranContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouse { get;set; }

        public async Task OnGetAsync()
        {
            Warehouse = await _context.Warehouses.ToListAsync();
        }
    }
}
