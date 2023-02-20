using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BindBox.Controllers
{
    public class CommdityDetailController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private static string Img;
        public IConfiguration Configuration { get; }

        public CommdityDetailController(MyDbContext context, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: CommdityDetailController
        public async Task<ActionResult> IndexAsync()
        {
            ViewBag.CommdityDetails=await _context.CommdityDetails.ToListAsync();
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
        public async Task<IActionResult> Create([Bind("CommdityDetailId,ComminfoName,ComminfoSpec,ComminfoPrice,OfficiaPrice")] CommdityDetail commdityDetail)
        {
            if (!ModelState.IsValid)
            {
                commdityDetail.ComminfoImg = Img;
                _context.Add(commdityDetail);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(IndexAsync));
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

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            var files = Request.Form.Files;
            if (files.Count == 0)
            {
                return Json(new { code = 1, data = "没有选择的图片！" });
            }
            var file = files[0];
            string fileName = file.FileName;
            if (string.IsNullOrEmpty(fileName))//服务器是否存在该文件
            {
                return Json(new { code = 1, data = "服务器上已存在该图片！" });
            }
            // 获取上传的图片名称和扩展名称
            string fileFullName = Path.GetFileName(file.FileName);
            string fileExtName = Path.GetExtension(fileFullName);
            var fileExtNames = Configuration["FileExtName"].Split(',');
            if (!fileExtNames.Contains(fileExtName))
            {
                return Json(new { code = 1, data = "选择的文件不是图片的格式！" });
            }
            //获取当前项目所在的路径
            string imgPath = Configuration["ImgPath"];
            //var newPath = fileFullName.Substring(0, fileFullName.IndexOf(fileExtName)) + System.DateTime.UtcNow.Ticks + fileExtName;
            //新文件名称
            //var newPath = System.DateTime.UtcNow.Ticks + fileExtName;
            var src = imgPath + fileFullName;
            // 如果目录不存在则要先创建
            if (!Directory.Exists(imgPath))
            {
                Directory.CreateDirectory(imgPath);
            }
            using (FileStream fs = System.IO.File.Create(src))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            var folder = Configuration["ImgFolder"] + fileFullName;
            Img = GetCompleteUrl(folder);
            ///return newPath;
            return Json(new { code = 0, data = src });
        }

        private string GetCompleteUrl(string scr)
        {
            return new StringBuilder()
                 .Append(HttpContext.Request.Scheme)
                 .Append("://")

                 .Append(HttpContext.Request.Host)
                 .Append(scr)
                 .ToString();
        }

    }

}
