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
    public class ProcessAreaService : BaseService<ProcessArea>, IProcessAreaService
    {
        public ProcessAreaService(IProcessAreaRepository _iProcessAreaService) : base(_iProcessAreaService)
        {

        }
    }
}
