
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IRespository
{
    public interface IBaseRepository<MISAEntities>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của 1 kiểu đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
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
        public IEnumerable<MISAEntities> GetPaging(int PageSize, int PageNumber, string WhereClause , string Sort,ref int TotalRecord);

        /// <summary>
        /// Lấy đối tượng theo id
        /// </summary>
        /// <param name="id"> id đối tượng cần lấy</param>
        /// <returns>Đối tượng theo yêu cầu</returns>
        /// created by ndluc(07/07/2021)
        public MISAEntities GetById(Guid id);

        /// <summary>
        /// Xóa đối tượng theo  Id
        /// </summary>
        /// <param name="id"> id đối tượng cần xóa</param>
        /// <returns>Số lượng đối tượng bị xóa</returns>
        /// created by ndluc(07/07/2021)
        public int DeleteById(Guid id, string tableDelete = null, string property = null);

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
        public int Insert(MISAEntities entitiy);

        /// <summary>
        /// Lấy mã mới cho đối tượng được thêm mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// created by ndluc(07/07/2021)
        public string GetNewCode();

        /// <summary>
        /// Kiểm tra giá trị đã bị trùng trong hệ thống hay không
        /// </summary>
        /// <param name="ValueCheck">giá trị cần kiểm tra</param>
        /// <param name="propertyName"> thuộc tính của giá trị</param>
        /// <param name="entityId"> id của đối tượng chứa thuộc tính cần kiểm tra giá trị</param>
        /// <returns>Dúng hoặc sai</returns>
        /// created by ndluc(08/07/2021)
        public bool CheckExists(string ValueCheck, string propertyName, string entityId = null);

        /// <summary>
        /// Thêm một danh sách đối tượng
        /// </summary>
        /// <param name="listEntities"> Danh sách đối tượng cần thêm</param>
        /// <returns>Tổng số bản ghi được thêm</returns>
        /// created by ndluc(09/07/2021)
        public int InsertList(List<MISAEntities> listEntities,string tableName = null);

    }
}
