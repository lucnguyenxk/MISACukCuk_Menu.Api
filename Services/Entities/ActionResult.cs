using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// Đối tượng chứa kết quả trả về cho client
    /// </summary>
    public class ActionResult
    {
        /// <summary>
        /// trạng thái kết quả trả về  
        /// </summary>
        /// created by ndluc(12/07/2021)
        public int StatusCode { get; set; }

        /// <summary>
        /// thông báo dành cho client
        /// </summary>
        /// created by ndluc(12/07/2021)
        public string UserMessage { get; set; }

        /// <summary>
        /// thông báo dành cho lâp trình viên
        /// </summary>
        /// created by ndluc(12/07/2021)
        public string DevMessage { get; set; }

        /// <summary>
        /// Dữ liệu trả về cho client
        /// </summary>
        /// created by ndluc(12/07/2021)
        public dynamic Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// created by ndluc(12/07/2021)
        public int TotalRecord { get; set; }

        public ActionResult(int statusCode, string userMsg, string devMsg , dynamic data , int totalRecord)
        {
            StatusCode = statusCode;
            UserMessage = userMsg;
            DevMessage = devMsg;
            Data = data;
            TotalRecord = totalRecord;
        }
        public ActionResult(int statusCode, string userMsg, string devMsg, dynamic data)
        {
            StatusCode = statusCode;
            UserMessage = userMsg;
            DevMessage = devMsg;
            Data = data;
        }


    }
}
