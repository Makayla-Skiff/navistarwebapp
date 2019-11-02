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
    public class DeleteModel : PageModel
    {
        private readonly NavistarWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(NavistarWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdminPage = await _context.AdminPage.FindAsync(id);

            if (AdminPage != null)
            {
                _context.AdminPage.Remove(AdminPage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
