using BindBox.Models;
using BindBox.Models.HelpModel;

namespace BindBox.DAO
{
    public interface ICommdityDetailService:IModelService<CommdityDetail>
    {
       public List<DescInfo> GetDescInfo(CommdityDetail commdityDetails);
    }
}