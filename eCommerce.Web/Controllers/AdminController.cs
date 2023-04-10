using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.DTOs.Products;
using eCommerce.Service.DTOs.Users;
using eCommerce.Service.Interfaces;
using eCommerce.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService = new UserService();


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserManagement()
        {
            var users = await _userService.GetServiceAllAsync(u => true);

            return View(users);
        }

        public async Task<IActionResult> UserDetails(long id)
        {
            return View(await _userService.GetServiceAsync(u => u.Id == id));
        }
        //-----------------------------------------------------------------------------------------
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate(UserCreationDto user)
        {
            var existingUser = await _userService.GetServiceAsync(u => u.Email == user.Email);

            if (ModelState.IsValid && existingUser == null)
            {
                var result = await _userService.CreateServiceAsync(user);
                return RedirectToAction("UserManagement");
            }

            return View(user);
        }
        //--------------------------------------------------------------------------------------------

        public async Task<IActionResult> UserEdit(long id)
        {
            var user = await _userService.GetServiceAsync(u => u.Id == id);

            var userCreationDto = new UserCreationDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Phone = user.Phone,
                Email = user.Email,
                Role = user.Role
            };

            return View(userCreationDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(long id, UserCreationDto user)
        {
            if (ModelState.IsValid)
            {
                var updatedProduct = await _userService.UpdateServiceAsync(u => u.Id == id, user);
                return RedirectToAction("UserManagement");
            }
            return View(user);
        }
        //----------------------------------------------------------------------------------------------

        public async Task<IActionResult> UserDelete(long id)
        {

            var user = await _userService.GetServiceAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var userCreationDto = new UserCreationDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Phone = user.Phone,
                Email = user.Email,
                Role = user.Role
            };

            return View(userCreationDto);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDeleteConfirmed(int id)
        {
            await _userService.DeleteServiceAsync(u => u.Id == id);

            return RedirectToAction("UserManagement");
        }


        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        //----------------------------------------Product management admin-----------------------------------\\

        private readonly IProductService  _productService = new ProductService();


        public async Task<IActionResult> ProductManagement()
        {
            var products = await _productService.GetServiceAllAsync(p => true);
            return View(products);
        }


        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductCreationDto product)
        {
            var existingUser = await _productService.GetServiceAsync(u => u.ProductName == product.ProductName);

            if (ModelState.IsValid && existingUser == null)
            {
                var result = await _productService.CreateServiceAsync(product);
                return RedirectToAction("ProductManagement");
            }

            return View(product);
        }


    }
}
