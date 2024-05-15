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

    public class SubCategoryController : Controller
    {
        private readonly ISubcategoryRepository _subCategoryRepository;
        private readonly ICategoryRepository _CategoryRepository;


        public SubCategoryController(ISubcategoryRepository subCategoryRepository,ICategoryRepository categoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _CategoryRepository = categoryRepository;
        }


        public async Task<IActionResult> ShowSubCategory()
        {
            var subCategories = await _subCategoryRepository.GetAllSubcategories();
            return View(subCategories);
        }

       
        public async Task<IActionResult> AddSubCategoryAsync()
        {

            var category = await _CategoryRepository.GetAllCategories();

            ViewBag.category = new SelectList(category, "Category_Id", "Category_Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubCategory(Subcategory subCategory)
        {
            if (ModelState.IsValid)
            {
                await _subCategoryRepository.AddSubcategory(subCategory);
                return RedirectToAction(nameof(ShowSubCategory));
            }
            return View(subCategory);
        }

        // GET: /SubCategory/Edit/1
        public async Task<IActionResult> UpdateSubCategory(int id)
        {
            var subCategory = await _subCategoryRepository.GetSubcategoryById(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            var category = await _CategoryRepository.GetAllCategories();

            ViewBag.category = new SelectList(category, "Category_Id", "Category_Name");
            return View(subCategory);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSubCategory(Subcategory subCategory)
        {
          
            if (ModelState.IsValid)
            {
                await _subCategoryRepository.UpdateSubcategory(subCategory);
                return RedirectToAction(nameof(ShowSubCategory));
            }
            return View(subCategory);
        }

     
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await _subCategoryRepository.GetSubcategoryById(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        [HttpPost, ActionName("DeleteSubCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deletionResult = await _subCategoryRepository.DeleteSubcategory(id);

            if (deletionResult)
            {
                TempData["Subcategory_Delete_Success"] = "Subcategory deleted successfully.";
            }
            else
            {
                TempData["Subcategory_Delete_Error"] = "Error occurred while deleting the subcategory.";
            }

            return RedirectToAction(nameof(ShowSubCategory));
        }

    }
}
