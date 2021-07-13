using Services.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Trạng thái của đối tượng
        /// </summary>
        /// created by ndluc(08/07/2021)
        public EntityState EntityState { get; set; } = EntityState.Add;


        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        /// created by ndluc(07/07/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string CreatedBy { get; set; }



    }
}
