namespace BindBox.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        // GET: Grade
        public async Task<ActionResult> IndexAsync()
        {
            return View(await _gradeService.ModelQueryable.ToListAsync());
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
                await _gradeService.CreateAsync(grade);
            }
            return RedirectToAction(nameof(IndexAsync));
        }

        // GET: Grade/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            if (id == null || _gradeService.ModelQueryable == null)
            {
                return NotFound();
            }

            var grade = await _gradeService.SingAsync(id);
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
            await _gradeService.UpdateAsync(grade);
            return RedirectToAction(nameof(Index));
        }

        // GET: Grade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _gradeService.ModelQueryable == null)
            {
                return NotFound();
            }
            await _gradeService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
