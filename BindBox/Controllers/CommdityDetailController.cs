using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BindBox.Controllers
{
    public class CommdityDetailController : Controller
    {
        private readonly MyDbContext _context;

        public CommdityDetailController(MyDbContext context)
        {
            _context = context;
        }
        // GET: CommdityDetailController
        public async Task<ActionResult> IndexAsync()
        {
            return View(await _context.Grades.ToListAsync());
        }

        // GET: CommdityDetailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommdityDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommdityDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommdityDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommdityDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommdityDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommdityDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
