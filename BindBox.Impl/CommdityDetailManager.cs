using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
using BindBox.Models.HelpModel;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Impl
{
    public class CommdityDetailManager : ICommdityDetailService
    {
        private MyDbContext _context;
        public CommdityDetailManager(MyDbContext context)
        {
            this._context = context;
        }

        public IQueryable<CommdityDetail> ModelQueryable => _context.CommdityDetails;

        public async Task<bool> CreateAsync(CommdityDetail t)
        {
            try
            {
                t.Grade = _context.Grades.SingleOrDefault(x => x.GradeId == t.FKGradeId);
                _context.Add(t);
                int r = await _context.SaveChangesAsync();
                return r > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int? t)
        {
            try
            {
                var grade = await SingAsync(t);
                if (grade != null)
                {
                    grade.IsDelete = true;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch
            {

                return false;
            }
        }

        public async Task<CommdityDetail> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.CommdityDetailId == t);
        }

        public async Task<bool> UpdateAsync(CommdityDetail t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public List<DescInfo> GetDescInfo(CommdityDetail commdityDetails)
        {
            List<DescInfo> descInfos = new List<DescInfo>();
            foreach (var item in commdityDetails.DescribeTypes)
            {
                descInfos.Add(new DescInfo()
                {
                    DescribeTypeId = @item.DescribeTypeId,
                    DescTitle = @item.DescTitle,
                    DescContent = @item.DescContent
                });
            }
            return descInfos;
        }

        //private bool CommdityDetailsExists(int id)
        //{
        //    return ModelQueryable.Any(e => e.CommdityDetailId == id);
        //}
    }
}