using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
using Microsoft.EntityFrameworkCore;

namespace BindBox.Impl
{
    public class StaffServiceManager : IStaffService
    {
        private MyDbContext _context;
        public StaffServiceManager(MyDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Staff> ModelQueryable => _context.Staffs;

        public async Task CreateAsync(Staff t)
        {
            _context.Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? t)
        {
            var staff = await SingAsync(t);

            if (staff != null)
            {
                staff.StaffState = "离职";
                staff.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Staff> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.StaffId == t);
        }

        public async Task UpdateAsync(Staff t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (StaffExists(t.StaffId))
                {
                    throw;
                }
            }
        }

        private bool StaffExists(int id)
        {
            return ModelQueryable.Any(e => e.StaffId == id);
        }
    }
}