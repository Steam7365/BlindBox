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

        public async Task<bool> CreateAsync(Staff t)
        {
            _context.Add(t);
            int r= await _context.SaveChangesAsync();
            return r > 0;
        }

        public async Task<bool> DeleteAsync(int? t)
        {
            var staff = await SingAsync(t);

            if (staff != null)
            {
                staff.StaffState = "离职";
                staff.IsDelete = true;
                int r= await _context.SaveChangesAsync();
                return r > 0;
            }
            return false;
        }

        public async Task<Staff> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.StaffId == t);
        }

        public async Task<bool> UpdateAsync(Staff t)
        {
            try
            {
                _context.Update(t);
                int r = await _context.SaveChangesAsync();
                return (r > 0);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private bool StaffExists(int id)
        {
            return ModelQueryable.Any(e => e.StaffId == id);
        }
    }
}