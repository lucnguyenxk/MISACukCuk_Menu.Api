using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IService
{
    public interface IBaseService<MISAEntities>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của kiểu đối tượng
        /// </summary>
        /// <returns>Danh sách toàn bộ đối tượng</returns>
        /// created by ndluc(09/07/2021)
        public IEnumerable<MISAEntities> GetAll();

        /// <summary>
        /// Lấy dữ liệu có phân trang, lọc và sắp xếp theo tiêu chí chọn
        /// </summary>
        /// <param name="PageSize">Số bản ghi một trang</param>
        /// <param name="PageNumber">Số thứ tự trang</param>
        /// <param name="WhereClause">Tiêu chí lọc</param>
        /// <param name="Sort">Tiêu chí sắp xếp</param>
        /// <returns>Danh sách bản ghi theo yêu cầu</returns>
        /// created by ndluc(07/07/2021)
        public IEnumerable<MISAEntities> GetPaging(int PageSize, int PageNumber, string Sort, List<FilterData> listFilters, ref int totalRecord);

        /// <summary>
        /// update đối tượng theo Id
        /// </summary>
        /// <param name="id">id đối tượng cần update</param>
        /// <param name="entity">đối tượng chứa các giá trị cần update</param>
        /// <returns>số lượng đối tượng được update</returns>
        /// created by ndluc(07/06/2021)
        public int Update(Guid id, MISAEntities entity);

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity"> đối tượng được thêm mới</param>
        /// <returns>số lượng đối tượng được thêm  mới</returns>
        /// created by ndluc(07/07/2021)
        public int Insert(MISAEntities entity);

        /// <summary>
        /// Lấy mã mới cho đối tượng được thêm mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// created by ndluc(07/07/2021)
        public string GetNewCode();

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="id">id đối tượng bị xóa</param>
        /// <returns> số lượng bản ghi bị xóa</returns>
        /// created by ndluc(10/07/2021)
        public int Delete(Guid id);
    }
}
