using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IService
{
    public interface IMenuService : IBaseService<Menu>
    {
        /// <summary>
        /// Lấy code mới cho thực đơn  dựa vào tên
        /// </summary>
        /// <param name="nameOfMenu">Tên của thực đơn cần lấy mã</param>
        /// <returns></returns>
        public string getNewCode();
    }
}
