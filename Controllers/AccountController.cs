using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFItness.Data;
using MyFItness.Models;
using System.Security.Claims;
namespace MyFItness.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfos(ApplicationUser model)
        {
                var user = await _userManager.GetUserAsync(User);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.DateOfBirth = model.DateOfBirth;
                user.HeightCm = model.HeightCm;
                user.WeightLbs = model.WeightLbs;
                user.BodyFatPercentage = model.BodyFatPercentage;
                user.Gender = model.Gender;
                user.FitnessGoal = model.FitnessGoal;
                user.IsTrainer = model.IsTrainer;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }

            return View(model);
            }

        }


    }
