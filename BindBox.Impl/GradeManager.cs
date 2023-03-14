using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
using Microsoft.EntityFrameworkCore;

namespace BindBox.Impl
{
    public class GradeManager : IGradeService
    {
        private MyDbContext _context;
        public GradeManager(MyDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Grade> ModelQueryable => _context.Grades;

        public async Task<bool> CreateAsync(Grade t)
        {
            _context.Add(t);
            int r= await _context.SaveChangesAsync();
            return r > 0;
        }

        public async Task<bool> DeleteAsync(int? t)
        {
            var grade = await SingAsync(t);

            if (grade != null)
            {
                grade.IsDelete = true;
                int r= await _context.SaveChangesAsync();
                return r > 0;
            }
            else
                return false;
        }

        public async Task<Grade> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.GradeId == t);
        }

        public async Task<bool> UpdateAsync(Grade t)
        {
            try
            {
                _context.Update(t);
                 int r = await _context.SaveChangesAsync();
                return r > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        private bool GradeExists(int id)
        {
            return ModelQueryable.Any(e => e.GradeId == id);
        }
    }
}