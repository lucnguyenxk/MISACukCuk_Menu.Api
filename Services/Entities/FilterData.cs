using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// đối tượng lưu thông tin để lọc dữ liệu 
    /// </summary>
    /// created by ndluc(08/07/2021)
    public class FilterData :BaseEntity
    {
        /// <summary>
        /// Tên trường được lọc dữ liệu
        /// </summary>
        /// created by ndluc(08/07/2021)
        public string FilterProperty { get; set; }

        /// <summary>
        /// Giá trị cần lọc dữ liệu
        /// </summary>
        /// created by ndluc(08/07/2021)
        public dynamic FilterValue { get; set; }

        /// <summary>
        /// Loại lọc dữ liệu 
        /// </summary>
        /// created by ndluc(08/07/2021)
        public int FilterType { get; set; }

        /// <summary>
        /// Xác nhận có được sort hay không
        /// </summary>
        /// created by ndluc(08/07/2021)
        public bool IsSort { get; set; }

        /// <summary>
        /// Xác định kiểu Sort
        /// </summary>
        /// created by ndluc(08/07/2021)
        public string SortType { get; set; }
    }
}
