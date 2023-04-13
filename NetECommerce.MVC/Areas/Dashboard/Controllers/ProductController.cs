using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Common;
using NetECommerce.Entity.Entity;
using NetECommerce.MVC.Areas.Dashboard.ViewModels;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetECommerce.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAllProducts().ToList());
        }

        public IActionResult Create()
        {

            //SelectListItem => Mvc tarafında bize teslim edilen SelectListItem view içerinde oluşturmuş olduğumuz <select></select> etiketi içerisinde selectlist oluşturmamıza olanak sağlayan bir sınıftır.
            ViewBag.Categories = _categoryService.GetAllCategorys().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()


            });
            return View();
        }


        [HttpPost]
        public  async Task<IActionResult> Create(ProductVM productVM,IFormFile ImagePath)//
        {
            string path = "";

            var imageResult=ImageUploader.ImageChangeName(ImagePath.FileName);

            if (imageResult != "1")
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imageResult);

                using(var stream=new FileStream(path, FileMode.Create))
                {
                   await ImagePath.CopyToAsync(stream);
                }
                productVM.ImagePath = imageResult;


            }
            else
            {
                TempData["result"] = "format uymuyor!";
                return View();
            }


            //ImageUploader

            Product product = new Product
            {
                ProductName = productVM.ProductName,
                UnitPrice = productVM.UnitPrice,
                UnitsInStock = productVM.UnitsInStock,
                CategoryId = productVM.Category.Id,
                Description = productVM.Description,
                ImagePath=productVM.ImagePath
                

            };

           TempData["result"]= _productService.CreateProduct(product);

            return RedirectToAction("Index");
        }
    }
}
