using Services.Commons.Attributes;
using Services.Commons.Enums;
using Services.Commons.Exceptions;
using Services.Entities;
using Services.Interfaces.IRespository;
using Services.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    /// <summary>
    /// Service dùng chung cho các đối tượng
    /// </summary>
    /// <typeparam name="MISAEntities"></typeparam>
    /// created by ndluc(07/07/2021)
    public class BaseService<MISAEntities> : IBaseService<MISAEntities> where MISAEntities:BaseEntity
    {
        #region Properties
        IBaseRepository<MISAEntities> iBaseRepostitory;
        #endregion
        #region Constructor
        public BaseService(IBaseRepository<MISAEntities> _iBaseRepository)
        {
            iBaseRepostitory = _iBaseRepository;   
        }
        #endregion
        public string GetNewCode()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MISAEntities> GetPaging(int PageSize, int PageNumber, string Sort,List<FilterData> listFilters, ref int TotalRecord)
        {
            var WhereClause = new StringBuilder();
            Sort = "";
            //kiểm tra nếu ko có yêu cầu lọc thì lấy hết dữ liệu
            if (listFilters.Count() == 0)
            {
                WhereClause.Append("1=1");
                Sort += "CreatedDate Desc";
            }
            else
            {
                var indexOfFilterData = 1;
                foreach(var filterData in listFilters)
                    {
                    
                    if (filterData.FilterValue is not null)
                    {
                        //thực hiện nối mệnh đề
                        if (indexOfFilterData < listFilters.Count()+1 && indexOfFilterData > 1)
                        {
                            WhereClause.Append(" And ");
                        }
                        WhereClause.Append("(");
                        WhereClause.Append(filterData.FilterProperty);
                        // kiểm tra nếu giá trị lọc mà rỗng thì sẽ lấy tất cả dữ liệu
                        if(filterData.FilterValue.ToString()=="")
                        {
                            WhereClause.Append(" LIKE");
                            WhereClause.Append(" CONCAT('%', '");
                            WhereClause.Append("");
                            WhereClause.Append("','%')");
                            WhereClause.Append("Or ");
                            WhereClause.Append(filterData.FilterProperty);
                            WhereClause.Append(" Is Null )");
                        }
                        else
                        {
                            // build mệnh đề cho câu lệnh where
                            BuildWhereClause(filterData, WhereClause);
                        }    
                        
                    }

                    //Build mệnh đề sort
                    if (filterData.IsSort == true)
                    {
                        if (Sort.Length > 0)
                        {
                            Sort += ",";
                        }
                        Sort = Sort + " " + filterData.FilterProperty + " " + filterData.SortType;
                    }
                    indexOfFilterData++;
                }
            }
            if (Sort == "") Sort = "CreatedDate Desc";
            var entities = iBaseRepostitory.GetPaging(PageSize, PageNumber, WhereClause.ToString(), Sort, ref TotalRecord);
            return entities;
        }

        public virtual int Insert(MISAEntities entity)
        {
            
            Validate(entity);            
            var res = iBaseRepostitory.Insert(entity) ;
            return res;

        }

        public virtual int Update(Guid id, MISAEntities entity)
        {
            entity.EntityState = EntityState.Update;
            Validate(entity);
            var res = iBaseRepostitory.Update(id, entity);
            return res;
        }

        /// <summary>
        /// Build từng mệnh đề cho câu lệnh Where
        /// </summary>
        /// <param name="filterData">trường thông tin cần lọc</param>
        /// <param name="WhereClause"> câu lệnh where</param>
        /// created by ndluc(08/07/2021)
        private void BuildWhereClause(FilterData filterData, StringBuilder WhereClause)
        {
            switch (filterData.FilterType)
            {
                case 1:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT('%', '");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("','%'))");
                    break;
                case 2:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT('");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("','%'))");
                    break;
                case 3:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT('%','");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("'))");
                    break;
                case 4:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT( '");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("'))");
                    break;
                case 5:
                    WhereClause.Append(" NOT LIKE");
                    WhereClause.Append(" CONCAT('%', '");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("','%'))");
                    break;
                case 6:
                    WhereClause.Append(" <= ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 7:
                    WhereClause.Append(" < ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 8:
                    WhereClause.Append(" = ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 9:
                    WhereClause.Append(" >= ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 10:
                    WhereClause.Append(" > ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
            }
        }

        /// <summary>
        /// Validate đối tượng trước khi thêm hoặc sửa
        /// </summary>
        /// <param name="entity"> đối tượng cần validate thông tin</param>
        protected virtual void Validate(MISAEntities entity)
        {
            var properties = typeof(MISAEntities).GetProperties();
            var entityId = properties[0].GetValue(entity).ToString();
            foreach (var property in properties)
            {
                var nonDuplicate = property.GetCustomAttributes(typeof(NonDuplicate), true);
                if(nonDuplicate.Length > 0)
                {
                    var duplicate = false;

                    var propertyValue = property.GetValue(entity).ToString();
                    if (entity.EntityState == EntityState.Add)
                    {
                        duplicate = iBaseRepostitory.CheckExists(propertyValue, property.Name);
                    }
                    else
                    {
                        duplicate = iBaseRepostitory.CheckExists(propertyValue, property.Name, entityId);
                    }
                    if (duplicate)
                    {
                        var ErrMsg = String.Format((nonDuplicate[0] as NonDuplicate).MsgErr, propertyValue);
                        throw new ValidateException(ErrMsg, property.Name);
                    }
                }
            }

        }

        public IEnumerable<MISAEntities> GetAll()
        {
            var res = iBaseRepostitory.GetAll();
            return res;
        }

        public virtual int Delete(Guid id)
        {
            var res = iBaseRepostitory.DeleteById(id);
            return res;
        }
    }
}
