using Ekka_Shopping.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ekka_Shopping.Views.Shared.Components
{
 
      
            public class AbcViewComponent : ViewComponent
            {
                private readonly EkkaContext db;

                public AbcViewComponent(EkkaContext context)
                {
                    db = context;
                }
                public IViewComponentResult Invoke()
                {
                    var gendersWithCategories = db.Genders
               .Include(g => g.Categories)
                   .ThenInclude(c => c.Subcategories)
                       .ThenInclude(sc => sc.Products)
               .ToList();

                    return View(gendersWithCategories);
                }
            }
        

   

}
