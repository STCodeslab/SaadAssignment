using Microsoft.AspNetCore.Mvc;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using System.Threading.Tasks;
using Ekka_Shopping.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Ekka_Shopping.Controllers
{
    [Authorize(Roles = "1")]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGenderRepository _genderRepository;


        public CategoryController(ICategoryRepository categoryRepository, IGenderRepository genderRepository)
        {
            _categoryRepository = categoryRepository;
            _genderRepository = genderRepository;
        }

    
        public async Task<IActionResult> ShowCategory()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return View(categories);
        }

        public async Task<IActionResult> AddCategoryAsync()
        {
            var genderlist = await _genderRepository.GetAllGenders();

            ViewBag.Gender = new SelectList(genderlist, "gender_id", "gender_name");
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddCategory(category);
                return RedirectToAction(nameof(ShowCategory));
            }
            return View(category);
        }

       
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            var genderlist = await _genderRepository.GetAllGenders();

            ViewBag.Gender = new SelectList(genderlist, "gender_id", "gender_name");
            return View(category);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCateogories(Category category)
        {
          

            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateCategory(category);
                return RedirectToAction(nameof(ShowCategory));
            }
            return View(category);
        }

  
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: /Category/Delete/1
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deletionResult = await _categoryRepository.DeleteCategory(id);

            if (deletionResult)
            {
                TempData["Category_Delete_Success"] = "Category deleted successfully.";
            }
            else
            {
                TempData["Category_Delete_Error"] = "Error occurred while deleting the category.";
            }

            return RedirectToAction(nameof(ShowCategory));
        }

    }
}
