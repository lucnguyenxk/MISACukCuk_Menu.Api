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
    }
}
