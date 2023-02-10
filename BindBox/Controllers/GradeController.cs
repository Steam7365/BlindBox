using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BindBox.Controllers
{
    public class GradeController : Controller
    {
        private readonly MyDbContext _context;

        public GradeController(MyDbContext context)
        {
            _context = context;
        }
        // GET: Grade
        public async Task<ActionResult> IndexAsync()
        {
            return View(await _context.Grades.ToListAsync());
        }

        // GET: Grade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeId,GradeName,Probability")] Grade grade)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAsync));
            }
            return View(grade);
        }

        // GET: Grade/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        // POST: Grade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeId,GradeName,Probability")] Grade grade)
        {
            if (id != grade.GradeId || ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                _context.Update(grade);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(grade.GradeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }

        // GET: Grade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.GradeId == id);

            if (grade == null)
            {
                return NotFound();
            }
            else
            {
                grade.IsDelete = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
