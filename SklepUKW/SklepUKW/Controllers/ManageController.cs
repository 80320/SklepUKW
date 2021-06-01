using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SklepUKW.App_Start;
using SklepUKW.Models;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            ChangeUserDataSuccess,
            DataError,
            Error
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Hasło zostało zmienione."
                : message == ManageMessageId.Error ? "Wystąpił błąd."
                : message == ManageMessageId.ChangeUserDataSuccess ? "Dane użytkownika zostały zmienione."
                : message == ManageMessageId.DataError ? "Wystąpił błąd z formularzem."
                : "";

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var model = new ManageViewModel
            {
                Message = message,
                UserData = user.UserData
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ManageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //return View(model);
                return RedirectToAction("Index", new { Message = ManageMessageId.DataError });
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.ChangePasswordsViewModel.OldPassword, model.ChangePasswordsViewModel.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            //return View(model);
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUserData(ManageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.DataError });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            user.UserData = model.UserData;
            var result = await UserManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangeUserDataSuccess });
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }
    }
}