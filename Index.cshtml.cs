using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NavistarWebApp.Data;

namespace NavistarWebApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly NavistarWebApp.Data.ApplicationDbContext _context;

        public IndexModel(NavistarWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AdminPage> AdminPage { get;set; }

        public async Task OnGetAsync()
        {
            AdminPage = await _context.AdminPage.ToListAsync();
        }
    }
}
