using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NavistarWebApp.Data;

namespace NavistarWebApp.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly NavistarWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(NavistarWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AdminPage AdminPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdminPage = await _context.AdminPage.FirstOrDefaultAsync(m => m.ADMIN_ID == id);

            if (AdminPage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
