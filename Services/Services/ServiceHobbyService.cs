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
    public class ServiceHobbyService : BaseService<ServiceHobby>, IServiceHobbyService
    {

        public ServiceHobbyService(IServiceHobbyRepository _IerviceHobbyRepository) : base(_IerviceHobbyRepository)
        {

        }
    }
}
