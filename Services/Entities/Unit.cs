using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// đối tượng đơn vị tính
    /// </summary>
    /// created by ndluc(07/07/2021)
    public class Unit :BaseEntity
    {
        /// <summary>
        /// id của đơn vị tính
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid UnitId { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string UnitName { get; set; }


        /// <summary>
        /// Mã đơn vị tính
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string UnitCode { get; set; }

    }
}
