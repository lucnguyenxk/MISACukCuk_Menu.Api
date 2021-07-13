
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// Đối tượng sở thích phục vụ
    /// </summary>
    /// created by ndluc(07/07/2021)
    public class ServiceHobby :BaseEntity
    {
        /// <summary>
        /// id của sở thích phục vụ
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid ServiceHobbyId { get; set; }

        /// <summary>
        /// Tên sở thích phục vụ
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string ServiceHobbyName { get; set; }

        /// <summary>
        /// Giá thu thêm
        /// </summary>
        /// created by ndluc(07/07/2021)
        public int? PriceAdd { get; set; }

        /// <summary>
        /// id của thực đơn chứa sở thích phục vụ
        /// </summary>
        /// created by ndluc(09/07/2021)
        public Guid MenuId { get; set; }
    }
}
