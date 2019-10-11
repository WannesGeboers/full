using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.BLL.Rules;
using dotNetAcademy.WEB.ViewModels.DefaultSettings;
using Microsoft.AspNetCore.Mvc;

namespace dotNetAcademy.WEB.Controllers
{
    public class DefaultSettingsController : Controller
    {
        public ActionResult Index()
        {
            var viewmodel = new SettingsViewModel
            {
                TotalSystemUsers = MaxAmount.MaxParticipantsInSystem
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind("MaxParticipantsInSystem")] SettingsViewModel s)
        {
            if (ModelState.IsValid)
            {
                MaxAmount.MaxParticipantsInSystem = s.TotalSystemUsers;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}