namespace BindBox.Controllers
{
    public class StaffsController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            return View(await _staffService.ModelQueryable.ToListAsync());
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffName,StaffWages,StaffGender,StaffPhone,StaffCode,StaffPosition,StaffState,Province,City,Area,Details")] Staff staff)
        {
            //if (ModelState.IsValid)
            //{
            await _staffService.CreateAsync(staff);
            return RedirectToAction(nameof(Index));
            //}
            //return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _staffService.ModelQueryable == null)
            {
                return NotFound();
            }

            var staff = await _staffService.SingAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffName,StaffWages,StaffGender,StaffPhone,StaffCode,StaffEntryTime,StaffPosition,StaffState,Image,Province,City,Area,Details")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            await _staffService.UpdateAsync(staff);
            return RedirectToAction(nameof(Index));
            //}
            //return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _staffService.ModelQueryable == null)
            {
                return NotFound();
            }

            await _staffService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
