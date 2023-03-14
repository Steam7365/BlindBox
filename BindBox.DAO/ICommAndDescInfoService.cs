using BindBox.Models.HelpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindBox.DAO
{
    public interface ICommAndDescInfoService
    {
        public Task<bool> Create(CommAndDescInfo commAndDescInfo);
        public Task<bool> Edit(CommAndDescInfo commAndDescInfo);
    }
}
