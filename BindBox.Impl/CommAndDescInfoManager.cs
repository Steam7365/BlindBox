using BindBox.DAO;
using BindBox.EF;
using BindBox.Models;
using BindBox.Models.HelpModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindBox.Impl
{
    public class CommAndDescInfoManager : ICommAndDescInfoService
    {
        public static string Img { get; set; }
        private ICommdityDetailService _commService;
        private MyDbContext _context;
        private IDescribeTypeService _descTypeService;
        public CommAndDescInfoManager(MyDbContext context, ICommdityDetailService commService, IDescribeTypeService descTypeService)
        {
            _commService = commService;
            _context = context;
            _descTypeService = descTypeService;
        }
        public async Task<bool> Edit(CommAndDescInfo commAndDescInfo)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //获取修改后的子商品信息
                var commdityDetail = new CommdityDetail()
                {
                    CommdityDetailId = commAndDescInfo.CommInfo.CommdityDetailId,
                    ComminfoName = commAndDescInfo.CommInfo.ComminfoName,
                    ComminfoPrice = commAndDescInfo.CommInfo.ComminfoPrice,
                    ComminfoSpec = commAndDescInfo.CommInfo.ComminfoSpec,
                    OfficiaPrice = commAndDescInfo.CommInfo.OfficiaPrice,
                    FKGradeId = commAndDescInfo.CommInfo.FKGradeId,
                    ComminfoImg = Img
                };
                bool isSuccess = await _commService.UpdateAsync(commdityDetail);

                //获取服务端中与该商品有关的描述列表
                var serverDesc = _descTypeService.ModelQueryable.
                        Include(x => x.CommdityDetails)
                        .Where(x => x.CommdityDetails.CommdityDetailId == commdityDetail.CommdityDetailId).AsNoTracking();

                //获取客户端发送过来的描述列表
                List<DescribeType> describeType = new List<DescribeType>();
                foreach (var item in commAndDescInfo.DescInfos)
                {
                    var des = new DescribeType();
                    des.DescTitle = item.DescTitle;
                    des.DescContent = item.DescContent;
                    des.DescribeTypeId = item.DescribeTypeId < 0 ? 0 : item.DescribeTypeId;
                    des.CommdityDetails = commdityDetail;
                    describeType.Add(des);
                    //如果id为0进行添加不然进行删除
                    if (des.DescribeTypeId==0)
                    {
                        await _descTypeService.CreateAsync(des);
                    }
                    else
                    {
                        await _descTypeService.UpdateAsync(des);
                    }
                }
                
                //获取差集
                var result = serverDesc.ToList().Where(x => !describeType.Any(y => y.DescribeTypeId == x.DescribeTypeId)).ToList();
                //将差集进行软删除
                result.ForEach(async x => await _descTypeService.DeleteAsync(x.DescribeTypeId));

                transaction.Commit();
                return isSuccess;
            }
            catch (Exception)
            {
                throw;
            }
        }


        ////遍历客户端的'类'描述信息列表
        //foreach (var item in commAndDescInfo.DescInfos)
        //{
        //    //判断数据库与客户端描述信息编号是否一致
        //    if (serverDescList.Exists(x => x.DescribeTypeId == item.DescribeTypeId))
        //    {
        //        //如果一致，将数据库信息的描述信息进行修改
        //        DescribeType type = new DescribeType()
        //        {
        //            DescribeTypeId = item.DescribeTypeId,
        //            DescTitle = item.DescTitle,
        //            DescContent = item.DescContent,
        //            CommdityDetails = commdityDetail
        //        };
        //        clientDescList.Add(type);
        //        await _descTypeService.UpdateAsync(type);
        //    }
        //    else
        //    {
        //        //如果不一致，将数据进行添加
        //        DescribeType type = new DescribeType()
        //        {
        //            DescTitle = item.DescTitle,
        //            DescContent = item.DescContent,
        //            CommdityDetails = commdityDetail
        //        };
        //        //await _descTypeService.CreateAsync(type);
        //        serverDescList.Add(type);
        //        clientDescList.Add(type);
        //        await _descTypeService.CreateAsync(type);
        //    }
        //}
        ////此时数据库的描述要么比客户端的描述完全一致，要么包含客户端的并且还多几个
        ////那么就要删除多出的那几个数据
        //List<DescribeType> remove = new List<DescribeType>();
        //foreach (var item in serverDescList)
        //{
        //    //删除
        //    if (!clientDescList.Exists(x=>x.DescribeTypeId==item.DescribeTypeId))
        //    {
        //        await _descTypeService.DeleteAsync(item.DescribeTypeId);
        //    }
        //}
        public async Task<bool> Create(CommAndDescInfo commAndDescInfo)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var commdityDetail = new CommdityDetail()
                {
                    ComminfoName = commAndDescInfo.CommInfo.ComminfoName,
                    ComminfoPrice = commAndDescInfo.CommInfo.ComminfoPrice,
                    ComminfoSpec = commAndDescInfo.CommInfo.ComminfoSpec,
                    OfficiaPrice = commAndDescInfo.CommInfo.OfficiaPrice,
                    FKGradeId = commAndDescInfo.CommInfo.FKGradeId,
                    ComminfoImg = Img
                };

                List<DescribeType> descList = new List<DescribeType>();
                foreach (var item in commAndDescInfo.DescInfos)
                {
                    DescribeType type = new DescribeType()
                    {
                        DescTitle = item.DescTitle,
                        DescContent = item.DescContent,
                        CommdityDetails = commdityDetail
                    };
                    descList.Add(type);
                }
                commdityDetail.DescribeTypes = descList;
                bool isSuccess = await _commService.CreateAsync(commdityDetail);
                transaction.Commit();
                return isSuccess;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
