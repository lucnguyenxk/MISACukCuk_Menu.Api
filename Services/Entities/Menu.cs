using Services.Commons.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// Đối tượng thực đơn
    /// </summary>
    /// created by ndluc(07/07/2021)
    public class Menu : BaseEntity
    {
        /// <summary>
        /// id của thực đơn
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid MenuId { get; set; }

        /// <summary>
        /// Tên thực đơn
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string MenuName { get; set; }


        /// <summary>
        /// Mã thực đơn
        /// </summary>
        /// created by ndluc(07/07/2021)
        [NonDuplicate("Mã thực đơn <{0}> đã tồn tại trong hệ thống,vui lòng kiểm tra lại!")]
        public string MenuCode { get; set; }


        /// <summary>
        /// id của nhóm thực đơn tương ứng
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid MenuGroupId { get; set; }

        /// <summary>
        /// Tên nhóm thực đơn
        /// </summary>
        /// created by ndluc(08/07/2021)
        public string MenuGroupName { get; set; }

        /// <summary>
        /// Id của đơn vị tính tương ứng
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid UnitId { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        /// created by ndluc(08/07/2021)
        public string UnitName { get; set; }

        /// <summary>
        /// id của nơi chế biến 
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid ProcessAreaId { get; set; }

        /// <summary>
        /// Tên nơi chế biến
        /// </summary>
        /// created by ndluc(08/07/2021)
        public string ProcessAreaName { get; set; }


        /// <summary>
        /// Giá bán
        /// </summary>
        /// created by ndluc(07/07/2021)
        public int? PriceSell { get; set; }


        /// <summary>
        /// Giá vốn
        /// </summary>
        public int? PriceCost { get; set; }


        /// <summary>
        /// Hiện trên trên menu chính hay không
        /// </summary>
        /// created by ndluc(07/07/2021)
        public bool? IsShowOnMenu { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string Description { get; set; }

        /// <summary>
        /// Danh sách sở thích phục vụ
        /// </summary>
        /// created by ndluc(08/07/2021)
        public List<ServiceHobby> ListServiceHobby { get; set; }

        /// <summary>
        /// Mã do Server gửi cho người dùng
        /// </summary>
        /// created by ndluc(14/07/2021)
        public string ServerCode { get; set; }

        /// <summary>
        /// Tiền tố của mã thực đơn
        /// </summary>
        /// created by ndluc(14/07/2021)
        public string PrefixCode { get; set; }

    }
}
