using Entity.Entity;
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.User;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Route("admin")]
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountController
        (
            UserManager<User> userManager,
            SignInManager<User> signInManager, 
            RoleManager<Role> roleManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region Register

        // GET
        [HttpGet("register")]
        [Authorize(Roles = "Blog Owner")]
        public IActionResult Register()
        {
            return View();
        }

        // POST
        [HttpPost("register")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Registration unsuccessful");
            }
            return View(model);
        }

        #endregion Register

        #region Login

        // GET
        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Your username or password is incorrect.");
            }

            return View(user);
        }

        #endregion Login

        #region Logout

        [Route("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        #endregion Logout

        [Route("users")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> ListUser()
        {
            return await Task.FromResult(View());
        }

        [Route("getusers")]
        [Authorize]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetAllUser()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new List<UserViewModel>();
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    var role = await _userManager.GetRolesAsync(item);

                    var userRole = new UserViewModel();
                    userRole.Id = item.Id;
                    userRole.FullName = item.FullName;
                    userRole.Email = item.Email;
                    userRole.Username = item.UserName;
                    if (role.Count > 0)
                    {
                        userRole.Roles = String.Join(", ", role);
                    }
                    userRoles.Add(userRole);
                }
            }
            var json = new { data = userRoles };
            return Json(json);
        }

        [Route("roles")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> ListRole()
        {
            return await Task.FromResult(View());
        }

        [Route("getroles")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetAllRole()
        {
            var roles = _roleManager.Roles.ToList();
            var roleViews = new List<RoleViewModel>();
            if (roles.Count > 0)
            {
                foreach (var item in roles)
                {
                    var roleView = new RoleViewModel();
                    roleView.Id = item.Id;
                    roleView.RoleName = item.Name;
                    roleViews.Add(roleView);
                }
            }

            var json = new { data = roleViews };
            return Json(json);
        }

        [Route("user/create")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> CreateUser()
        {
            ViewBag.Role = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return await Task.FromResult(View());
        }

        [Route("user/create")]
        [HttpPost]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FullName,
                    UserName = model.Username,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.Roles.Length > 0)
                    {
                        var listRole = model.Roles.Split(",").ToList();
                        foreach (var item in listRole)
                        {
                            await _userManager.AddToRoleAsync(user, item);
                        }
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("user/delete")]
        [Authorize(Roles = "Blog Owner")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [Route("role/create")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> CreateRole()
        {
            return await Task.FromResult(View());
        }

        [HttpPost("role/create")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            var role = new Role();
            role.Name = model.RoleName;
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("role/delete")]
        [Authorize(Roles = "Blog Owner")]
        [HttpPost]
        public async Task<IActionResult> DeleteRole(Guid roleId)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}