using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// Đối tượng chứa list các object filter data
    /// </summary>
    public class ListObjectFilter
    {
        public List<FilterData> ListFilterData { get; set; }
        public ListObjectFilter()
        {
            ListFilterData = new List<FilterData>();
        }
    }   
}
