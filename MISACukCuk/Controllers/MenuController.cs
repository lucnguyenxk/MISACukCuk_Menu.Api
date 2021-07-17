using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Interfaces.IRespository;
using Services.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Controllers
{
    
    public class MenuController : BaseController<Menu>
    {
        IMenuService iMenuService;
        IMenuRepository iMenuRepository; 
        public MenuController(IMenuService _iMenuService, IMenuRepository _iMenuRepository) : base(_iMenuService,_iMenuRepository)
        {
            iMenuRepository = _iMenuRepository;
            iMenuService = _iMenuService;
        }

        /// <summary>
        /// Lấy code mới cho thực đơn
        /// </summary>
        /// <param name="NameOfMenu">Tên của thực đơn để lấy code</param>
        /// <returns>Code của thực đơn</returns>
        [HttpGet("GetNewCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                var newCode = iMenuService.getNewCode();
                if (!String.IsNullOrEmpty(newCode))
                {
                    var actionResult = new Services.Entities.ActionResult(200, Properties.Resources.SuccedStatus, "",newCode);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Services.Entities.ActionResult(204, Properties.Resources.NoData, "", newCode);
                    return Ok(actionResult);
                }    
            }
            catch(Exception exception)
            {
                var actionResult = new Services.Entities.ActionResult(500, Properties.Resources.SystemErr, exception.Message, "");
                return Ok(actionResult);
            }
            
        }

    }
}
