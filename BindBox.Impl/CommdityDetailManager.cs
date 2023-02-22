using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
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

        public async Task CreateAsync(CommdityDetail t)
        {
            t.Grade = _context.Grades.SingleOrDefault(x => x.GradeId == t.FKGradeId);
            _context.Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? t)
        {
            var grade = await SingAsync(t);
            if (grade != null)
            {
                grade.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CommdityDetail> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.CommdityDetailId == t);
        }

        public async Task UpdateAsync(CommdityDetail t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CommdityDetailsExists(t.CommdityDetailId))
                {
                    throw;
                }
            }
        }
        private bool CommdityDetailsExists(int id)
        {
            return ModelQueryable.Any(e => e.CommdityDetailId == id);
        }
    }
}