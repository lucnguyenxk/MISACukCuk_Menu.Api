using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commons.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    /// <summary>
    /// Attribute đánh dấu các thuộc tính phải kiểm tra giá trị có bị trùng với các giá trị đã tồn tại trong hệ thống
    /// </summary>
    /// created by ndluc (08/07/2021)
    public class NonDuplicate : System.Attribute
    {
        public string MsgErr { get; set; }
        public NonDuplicate(string msgErr)
        {
            MsgErr = msgErr;
        }
    }
}
