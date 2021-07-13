using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commons.Enums
{
    /// <summary>
    /// Trạng thái của object
    /// </summary>
    /// Created by  ndluc(22/02/2021)
    public enum EntityState
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        Add = 1,

        /// <summary>
        /// Sửa
        /// </summary>
        Update = 2,

        /// <summary>
        /// Xoá
        /// </summary>
        Delete = 3
    }

    /// <summary>
    /// Trạng thái của giới tính
    /// </summary>
    /// Created by ndluc(22/02/2021)

    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,

        /// <summary>
        /// Nữ
        /// </summary>
        FeMale = 2,

        /// <summary>
        /// Khác
        /// </summary>
        Other = 0
    }
}
