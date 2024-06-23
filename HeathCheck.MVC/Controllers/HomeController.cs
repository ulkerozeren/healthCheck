using HeathCheck.MVC.ApiServices.Interfaces;
using HeathCheck.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HeathCheck.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationApiService _applicationService;

        public HomeController(IApplicationApiService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<IActionResult> Index(int userId)
        {
            var result = await _applicationService.GetApplicationsByUser(userId);

            return View(result);
        }

        public IActionResult Edit(int id, string name, string url)
        {
            UpdateApplicationModel model = new UpdateApplicationModel
            {
                Id = id,
                Name = name,
                Url = url
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddApplicationModel model)
        {
            var userId=HttpContext.Session.GetInt32("userId");
            if (userId != null)
                model.UserId = userId.Value;
           
            if (ModelState.IsValid)
            {
                await _applicationService.AddApplications(model);
                return RedirectToAction("Index", "Home", new { userId = model.UserId });
            }

            return RedirectToAction("SignIn", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateApplicationModel model)
        {
            if(ModelState.IsValid)
            {
                await _applicationService.UpdateApplications(model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _applicationService.DeleteApplication(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
