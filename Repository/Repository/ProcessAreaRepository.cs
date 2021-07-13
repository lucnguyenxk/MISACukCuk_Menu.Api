
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
    public class ProcessAreaRepository : BaseRepository<ProcessArea>,IProcessAreaRepository
    {
        public ProcessAreaRepository(IConfiguration iConfigruation) : base(iConfigruation)
        {

        }
    }
}
