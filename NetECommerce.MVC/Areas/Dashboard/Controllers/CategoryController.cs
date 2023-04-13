using Microsoft.AspNetCore.Mvc;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Entity.Entity;
using NetECommerce.MVC.Areas.Dashboard.ViewModels;
using System.Linq;

namespace NetECommerce.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategorys().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            Category category = new Category
            {
                CategoryName = categoryVM.CategoryName,
                Description = categoryVM.Description
            };
           
            
            
           TempData["result"]= _categoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var deleted = _categoryService.FindCategory(id);

            if (deleted != null)
            {
                TempData["result"] = _categoryService.DeleteCategory(deleted);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var updated = _categoryService.FindCategory(id);
            return View(updated);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            
            TempData["result"]= _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}
