using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
using Microsoft.EntityFrameworkCore;

namespace BindBox.Impl
{
    public class DescribeTypeManager : IDescribeTypeService
    {
        private MyDbContext _context;
        public DescribeTypeManager(MyDbContext context)
        {
            this._context = context;
        }

        public IQueryable<DescribeType> ModelQueryable => _context.DescribeTypes;

        public async Task<bool> CreateAsync(DescribeType t)
        {
            try
            {
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
                var describeType = await SingAsync(t);

                if (describeType != null)
                {
                    describeType.IsDelete = true;
                    int r = await _context.SaveChangesAsync();
                    return r > 0;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DescribeType> SingAsync(int? t)
        {
            return await ModelQueryable.SingleOrDefaultAsync(m => m.DescribeTypeId == t);
        }

        public async Task<bool> UpdateAsync(DescribeType t)
        {
            try
            {
                _context.Update(t);
                int r= await _context.SaveChangesAsync();
                return r > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        private bool GradeExists(int id)
        {
            return ModelQueryable.Any(e => e.DescribeTypeId == id);
        }
    }
}