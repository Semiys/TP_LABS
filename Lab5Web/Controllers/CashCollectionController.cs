using Microsoft.AspNetCore.Mvc;
using Lab5Web.Models;

namespace Lab5Web.Controllers
{
    public class CashCollectionController : Controller
    {
        private static CashCollection[] _collections = new CashCollection[10];
        private int GetCurrentIndex()
        {
            return int.TryParse(HttpContext.Request.Query["currentIndex"], out int index) ? index : 0;
        }
        public IActionResult Index()
        {
            ViewBag.CurrentIndex = GetCurrentIndex();
            ViewData["UseInternalHelper"] = true;
            return View(_collections.Where(c => c != null).ToArray());
        }
        public IActionResult Details(int id)
        {
            var collection = _collections.FirstOrDefault(c => c?.RouteNumber == id);
            if (collection == null)
            {
                return NotFound();
            }
            return View(collection);
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(CashCollection collection)
        {
            if (ModelState.IsValid)
            {
                int currentIndex = GetCurrentIndex();
                if (currentIndex< _collections.Length)
                {
                    _collections[currentIndex] = collection;
                    return RedirectToAction(nameof(Index), new { currentIndex = currentIndex+1 });
                }
            }
            return View(collection);
        }
        public IActionResult Edit(int id)
        {
            var collection = _collections.FirstOrDefault(c => c?.RouteNumber == id);
            if (collection == null)
            {
                return NotFound();
            }
            return View(collection);

        }
        
        [HttpPost]
        public IActionResult Edit(CashCollection collection)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < _collections.Length; i++)
                {
                    if (_collections[i]?.RouteNumber == collection.RouteNumber)
                    {
                        _collections[i] = collection;
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }
    }
}
