using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NavistarWebApp.Data;

namespace NavistarWebApp.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly NavistarWebApp.Data.ApplicationDbContext _context;

        public EditModel(NavistarWebApp.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AdminPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminPageExists(AdminPage.ADMIN_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdminPageExists(int id)
        {
            return _context.AdminPage.Any(e => e.ADMIN_ID == id);
        }
    }
}
