using Microsoft.AspNetCore.Mvc;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ekka_Shopping.Controllers
{

    [Authorize(Roles = "1")]

    public class GenderController : Controller
    {
        private readonly IGenderRepository _genderRepository;

        public GenderController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

       

        public async Task<IActionResult> ShowGender()
        {
            var genders = await _genderRepository.GetAllGenders();
            return View(genders);
        }

   
        public IActionResult AddGender()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGender(Gender gender)
        {
            if (ModelState.IsValid)
            {
                await _genderRepository.AddGender(gender);
                return RedirectToAction(nameof(ShowGender));
            }
            return View(gender);
        }

     
        public async Task<IActionResult> UpdateGender(int id)
        {
            var gender = await _genderRepository.GetGenderById(id);
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

        // POST: /Gender/UpdateGender/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateGender(Gender gender)
        {
            
            if (ModelState.IsValid)
            {
                await _genderRepository.UpdateGender(gender);
                return RedirectToAction(nameof(ShowGender));
            }
            return View(gender);
        }

 
        public async Task<IActionResult> DeleteGender(int id)
        {
            var gender = await _genderRepository.GetGenderById(id);
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

       
        [HttpPost, ActionName("DeleteGender")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGender(Gender gender)
        {
            bool deletionResult = await _genderRepository.DeleteGender(gender);

            if (deletionResult)
            {
                TempData["Gender_Delete_Success"] = "Gender deleted successfully.";
            }
            else
            {
                TempData["Gender_Delete_Error"] = "Error occurred while deleting the gender.";
            }

            return RedirectToAction(nameof(ShowGender));
        }

    }
}
