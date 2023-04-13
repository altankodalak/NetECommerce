using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Common;
using NetECommerce.Entity.Entity;
using NetECommerce.MVC.Models;
using NetECommerce.MVC.Models.ViewModels;
using NetECommerce.MVC.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetECommerce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IOrderService orderService;
        private readonly IOrderDetailService orderDetailService;

        public HomeController(IProductService productService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
        }

        public IActionResult Index()
        {
            //todo: sepete istekte bulunulduğunda tempdata okunmuyor.
            TempData["sepet"] = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            return View(productService.GetAllProducts().ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                //kullanıcı bilgilerini aldıktan sonra kayıt işlemi ardından kullanıcının mail adresine konfirmasyon mailinin gönderilmesi.

                AppUser appUser = new AppUser
                {
                    UserName = registerVM.Username,
                    Email = registerVM.Email,
                };


                var result = await userManager.CreateAsync(appUser, registerVM.ConfirmPassword);

                var registerToken = "";

                if (result.Succeeded)
                {


                    while (true)
                    {
                        registerToken = userManager.GenerateEmailConfirmationTokenAsync(appUser).Result;
                        if (!registerToken.Contains("/") && !registerToken.Contains("+"))
                        {
                            break;
                        }
                    }


                    MailSender.SendEmail(registerVM.Email, "Confirmation", $"{registerVM.Username} kayıt işleminiz başarılı şekilde oluşturuldu. Üyeliğinizi aktif edebilmek için linke tıklayın! https://localhost:44371/home/confirmation/" + appUser.Id + "/" + registerToken);

                    TempData["result"] = $"{appUser.UserName} adresine aktivasyon maili gönderildi! lütfen emailini kontrol edin...";
                    return View();
                }
                else
                {
                    return View();
                }


            }
            else
            {
                return View(registerVM);
            }

        }


        public IActionResult AddToCart(int id)
        {

            Cart cartSession;

            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null)
            {
                cartSession = new Cart();
            }
            else
            {
                cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            }



            var product = productService.GetById(id);

            CartItem cartItem = new CartItem();
            cartItem.Id = product.Id;
            cartItem.ProductName = product.ProductName;
            cartItem.UnitPrice = product.UnitPrice;

            cartSession.AddItem(cartItem);
            SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);


            return RedirectToAction("Index");


        }

        public IActionResult MyCart()
        {
            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
            {
                var sepet = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

                return View(sepet);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> CompleteCart()
        {
            Cart cart = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");


            if (User.Identity.IsAuthenticated)
            {
                Order order = new Order();
                var user = await userManager.GetUserAsync(User);
                order.User = user;
                Random rnd = new Random();
                order.Ordernumber = rnd.Next(1, 10000).ToString();
                OrderDetail orderDetail = new OrderDetail();
                foreach (var item in cart._myCart)
                {
                    Product product = productService.GetById(item.Value.Id);
                    product.ProductName = item.Value.ProductName;
                    product.UnitPrice = item.Value.UnitPrice;
                    orderDetail.Product = product;
                    orderDetail.Quantity=item.Value.Quantity;
                    orderDetail.UnitPrice = item.Value.UnitPrice;

                }
                order.OrderDetails.Add(orderDetail);
                orderService.CreateOrder(order);
                orderDetailService.CreateOrderDetails(orderDetail);

                MailSender.SendEmail(user.Email, "Sipariş Özeti", $"{order.Ordernumber} numaralı siparişiniz oluşturuldu. Kargoya verdiğimizde sizi bilgilendireceğiz.");

                SessionHelper.RemoveSession(HttpContext.Session, "sepet");

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }


        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginVM.Username);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {

                    return View();
                }
            }
            else
            {

            }
            return View(loginVM);
        }


        public async Task<IActionResult> Confirmation(int id, string registerCode)
        {
            if (id != null && registerCode != null)
            {
                var user = await userManager.FindByIdAsync(id.ToString());
                var confirm = await userManager.ConfirmEmailAsync(user, registerCode);
                if (confirm.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
