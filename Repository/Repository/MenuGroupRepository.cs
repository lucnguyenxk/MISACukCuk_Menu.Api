using Microsoft.Extensions.Configuration;
using Services.Entities;
using Services.Interfaces.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MenuGroupRepository : BaseRepository<MenuGroup>,IMenuGroupRepository
    {
        public MenuGroupRepository(IConfiguration iConfigruation) : base(iConfigruation)
        {

        }
    }
}
