using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.ViewModels;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 8)
        {
            List<Category> services = await _context.Categories
                .Where(s => !s.IsDeleted)
                .OrderByDescending(s => s.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .ToListAsync();
            int pageCount = await GetPageCount(take);

            PaginateVM<Category> model = new PaginateVM<Category>
            {
                Data = services,
                CurrentPage = page,
                PageCount = pageCount,
                HasNext = page < pageCount,
                HasPreview = page > 1,
                Take = take
            };

            return View(model);
        }
        private async Task<int> GetPageCount(int take)
        {
            int serviceCount = await _context.Categories.CountAsync();
            return (int)Math.Ceiling((double)serviceCount / take);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            bool isExists = await _context.Categories.AnyAsync(c =>
            c.Name.ToLower().Trim() == category.Name.ToLower().Trim());

            if (isExists)
            {
                ModelState.AddModelError("Name", "Category name already exists");
                return View(category);
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }









    }
}
