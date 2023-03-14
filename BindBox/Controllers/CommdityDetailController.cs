using BindBox.Extensions;
using BindBox.Models.HelpModel;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using X.PagedList;


namespace BindBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [FormatFilter]
    public class CommdityDetailController : Controller
    {
        private readonly ICommdityDetailService _commdityDetailService;
        private readonly ICommAndDescInfoService _commAndDescInfoService;
        private readonly IGradeService _gradeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IConfiguration Configuration { get; }
        #region 构造函数
        public CommdityDetailController(ICommdityDetailService commdityDetailService,
            IGradeService gradeService,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment,
            IHttpContextAccessor httpContextAccessor,
            ICommAndDescInfoService commAndDescInfoService)
        {
            _gradeService = gradeService;
            _commdityDetailService = commdityDetailService;
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _commAndDescInfoService = commAndDescInfoService;
        }
        // GET: CommdityDetailController

        #endregion

        [HttpGet]
        [Route("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            ViewBag.CommdityDetails = _commdityDetailService.ModelQueryable;
            return View(await _gradeService.ModelQueryable.ToListAsync());
        }

        #region 添加
        // GET: CommdityDetailController/Create/gid
        [Route("Create/{id}")]
        public ActionResult Create(int id)
        {
            var commdityDetail = new CommdityDetail();
            commdityDetail.FKGradeId = id;
            return View(commdityDetail);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommAndDescInfo commAndDescInfo)
        {
            bool b = await _commAndDescInfoService.Create(commAndDescInfo);
            if (b)
            {
                return Json("数据新增成功");
            }
            else
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region 修改
        // GET: CommdityDetailController/Edit/5
        [Route("Edit/{id?}/{gid}")]
        public async Task<ActionResult> EditAsync(int? id, int gid)
        {
            if (id == null || _commdityDetailService.ModelQueryable == null)
            {
                return NotFound();
            }
            var commdityDetails = await _commdityDetailService.ModelQueryable.Include(a => a.DescribeTypes).SingleAsync(x => x.CommdityDetailId == id);
            if (commdityDetails == null)
            {
                return NotFound();
            }
            CommAndDescInfoManager.Img = commdityDetails.ComminfoImg;
            commdityDetails.FKGradeId = gid;
            ViewBag.Json = JsonConvert.SerializeObject(_commdityDetailService.GetDescInfo(commdityDetails));
            return View(commdityDetails);
        }

        //// POST: CommdityDetailController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([Bind("CommdityDetailId, ComminfoName, ComminfoSpec, ComminfoPrice, OfficiaPrice, FKGradeId")] CommdityDetail commdityDetail)
        //{
        //    ModelState.RemoveAll(nameof(commdityDetail.Grade)
        //            , nameof(commdityDetail.BoxCommodities)
        //            , nameof(commdityDetail.Draws)
        //            , nameof(commdityDetail.DescribeTypes));
        //    commdityDetail.ComminfoImg = Img;
        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }
        //    await _commdityDetailService.UpdateAsync(commdityDetail);
        //    ViewBag.Result = "牛逼";
        //    return View(commdityDetail);
        //}

        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> EditAsync([FromBody] CommAndDescInfo commAndDescInfo)
        {
            try
            {
                bool b = await _commAndDescInfoService.Edit(commAndDescInfo);
                if (b)
                {
                    return Json("数据修改成功");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 删除
        // GET: CommdityDetailController/Delete/5
        [Route("Delete/{id?}")]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null || _commdityDetailService.ModelQueryable == null)
            {
                return NotFound();
            }
            await _commdityDetailService.DeleteAsync(id);


            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region 图片上传

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
            CommAndDescInfoManager.Img = GetCompleteUrl(folder);
            //return newPath;
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
        #endregion
    }

}
