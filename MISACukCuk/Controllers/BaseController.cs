using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commons.Exceptions;
using Services.Entities;
using Services.Interfaces.IRespository;
using Services.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<MISAEntities> : ControllerBase where MISAEntities : BaseEntity
    {
        /// <summary>
        /// Khởi tạo các đối tượng cần sử dụng
        /// </summary>
        /// created by ndluc(20/05/2021)
        #region Property and Constructor
        IBaseService<MISAEntities> iBaseService;
        IBaseRepository<MISAEntities> iBaseRepository;
        public BaseController(IBaseService<MISAEntities> _iBaseService, IBaseRepository<MISAEntities> _iBaseRepository)
        {
            iBaseRepository = _iBaseRepository;
            iBaseService = _iBaseService;
        }
        #endregion

        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// </summary>
        /// <param name="PageNumber">vị trí trang</param>
        /// <param name="PageSize">kích cỡ trang</param>
        /// <returns>Dữ liệu trả về có phân trang
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// </returns>
        /// created by ndluc(12/06/2021)
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(int PageSize, int PageNumber, string Sort, List<FilterData> listFilters)
        {
            try
            {
                var totalRecord = 0;
                var res = iBaseService.GetPaging(PageSize, PageNumber, Sort, listFilters, ref totalRecord);
                if (res.Count() == 0)
                {
                    var actionResult = new Services.Entities.ActionResult(204, "Không có dữ liệu trả về", "", 0);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res, totalRecord);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",exception.Message, 0);
                return Ok(actionResult);
            }


        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>toàn bộ dữ liệu</returns>
        /// created by ndluc(10/07/2021)
        /// /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                var res = iBaseService.GetAll();
                if(res.Count() > 0)
                {
                    var actionResult = new Services.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(204, "Không có dữ liệu trả về", "", 0);
                    return Ok(actionResult);
                }
            }
            catch( ValidateException exception)
            {
                var actionResult = new Services.Entities.ActionResult(400, exception.Message, "", 0);
                return Ok(actionResult);
            }
            catch(Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }

        }
        /// <summary>
        /// Lấy đội tượng theo id
        /// </summary>
        /// <param name="id">id đối tượng cần lấy</param>
        /// <returns> đối tượng cần lấy</returns>
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// created by ndluc(20/05/2021)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var res = iBaseRepository.GetById(id);
                if (res != null)
                {
                    var actionResult = new Services.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(204, "Không có dữ liệu trả về", "", 0);
                    return Ok(actionResult);
                }
            }
            catch(Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
            
        }
        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng được thêm mới</param>
        /// <returns>Số lượng đối tượng được thêm mới</returns>
        /// /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// created by ndluc(20/05/2021)
        [HttpPost]
        public IActionResult Insert(MISAEntities entity)
        {
            try
            {
                var res = iBaseService.Insert(entity);
                if (res > 0)
                {
                    var actionResult = new Services.Entities.ActionResult(200, "Thêm dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(204, "Thêm mới không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Services.Entities.ActionResult(400, exception.Message, "", 0);
                return Ok(actionResult);

            }
            catch (Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="id">id đối tượng cần sửa</param>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <returns>Số lượng đối tượng được sửa</returns>
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// created by ndluc(20/05/2021)
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, MISAEntities entity)
        {
            try
            {
                var res = iBaseService.Update(id,entity);
                if (res > 0)
                {
                    var actionResult = new Services.Entities.ActionResult(200, "Sửa dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(204, "Sửa không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Services.Entities.ActionResult(400, exception.Message, "", 0);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }
        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="id">id đối tượng cần xóa</param>
        /// <returns></returns>
        /// created by ndluc(07/07/2021)
        /// /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var res = iBaseService.Delete(id);
                if (res > 0)
                {
                    var actionResult = new Services.Entities.ActionResult(200, "Xóa dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(204, "Xóa không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch( ValidateException exception)
            {
                var actionResult = new Services.Entities.ActionResult(400, exception.Message, "", 0);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }
    }
}
