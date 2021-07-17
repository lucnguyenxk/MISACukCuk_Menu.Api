using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IRespository
{
    public interface IMenuRepository : IBaseRepository<Menu>
    {
        /// <summary>
        /// Lấy giá trị thứ tự lớn nhất ứng với tiền tố gửi lên
        /// </summary>
        /// <param name="NameOfMenu">Tiền tố gửi lên</param>
        /// <returns>Giá trị lớn nhất của mã ứng với tiền tố</returns>
        public string GetNewCode(string NameOfMenu, ref int Value);


        /// <summary>
        /// Thêm mới tiền tố 
        /// </summary>
        /// <param name="newPrefix">Tiền tố cần thêm</param>
        /// <returns>Số lượng bản ghi được thêm</returns>
        public int InsertNewPrefix(string newPrefix, int value);


        /// <summary>
        /// Cập nhật các giá trị tiền tố của mã
        /// </summary>
        /// <param name="prefix">tiền tố cần cập nhật</param>
        /// <param name="value">giá trị cập nhật</param>
        /// <returns>Số lượng bản ghi cần cập nhật</returns>
        public int UpDatePrefix(string prefix, int value);


    }
}
