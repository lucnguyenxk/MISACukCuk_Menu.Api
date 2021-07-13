using Services.Commons.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// Đối tượng nhóm thực đơn
    /// </summary>
    /// created by ndluc(07/07/2021)
    public class MenuGroup : BaseEntity
    {
        /// <summary>
        /// id của nhóm thực đơn
        /// </summary>
        public Guid MenuGroupId { get; set; }

        /// <summary>
        /// tên nhóm thực đơn
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string MenuGroupName { get; set; }

        /// <summary>
        /// mã nhóm thực đơn
        /// </summary>
        /// created by ndluc(07/07/2021)
        [NonDuplicate("Mã nhóm thực đơn {0} đã tồn tại, vui lòng kiểm tra lại.")]
        public string MenuGroupCode { get; set; }
    }
}
