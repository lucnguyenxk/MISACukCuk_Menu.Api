using Services.Entities;
using Services.Interfaces.IRespository;
using Services.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MenuGroupService : BaseService<MenuGroup>,IMenuGroupService
    {
        public MenuGroupService(IMenuGroupRepository _iMenuGroupRepository) : base(_iMenuGroupRepository)
        {
           

        }
    }
}
