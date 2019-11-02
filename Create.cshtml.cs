using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NavistarWebApp.Data;

namespace NavistarWebApp.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly NavistarWebApp.Data.ApplicationDbContext _context;

        public CreateModel(NavistarWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AdminPage AdminPage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdminPage.Add(AdminPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}