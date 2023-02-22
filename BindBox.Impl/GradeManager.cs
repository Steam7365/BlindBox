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

        public async Task CreateAsync(Grade t)
        {
            _context.Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? t)
        {
            var grade = await SingAsync(t);

            if (grade == null)
            {
                grade.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Grade> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.GradeId == t);
        }

        public async Task UpdateAsync(Grade t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GradeExists(t.GradeId))
                {
                    throw;
                }
            }
        }
        private bool GradeExists(int id)
        {
            return ModelQueryable.Any(e => e.GradeId == id);
        }
    }
}