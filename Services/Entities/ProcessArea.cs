using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class ProcessArea :BaseEntity
    {
        /// <summary>
        /// id nơi chế biến
        /// </summary>
        /// created by ndluc(07/07/2021)
        public Guid ProcessAreaId { get; set; }

        /// <summary>
        /// tên nơi chế biến
        /// </summary>
        /// created by ndluc(07/07/2021)
        public string ProcessAreaName { get; set; }
    }
}
