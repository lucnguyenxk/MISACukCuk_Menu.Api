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
    
    public class MenuGroupController : BaseController<MenuGroup>
    {
        public MenuGroupController(IMenuGroupService _iMenuGroupService, IMenuGroupRepository _iMenuGroupRepository) : base(_iMenuGroupService, _iMenuGroupRepository)
        {
            
        }
    }
}
