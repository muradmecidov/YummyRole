using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public MenuViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _context.Categories.OrderByDescending(c => c.IsActive).Include(c => c.Products).ToListAsync();
            return View(categories);
        }
    }
}
