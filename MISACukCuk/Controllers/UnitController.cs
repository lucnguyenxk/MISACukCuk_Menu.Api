﻿using Microsoft.AspNetCore.Http;
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
    public class UnitController : BaseController<Unit>
    {
        public UnitController(IUnitService _iUnitService , IUnitRepository _iUnitRepository) : base(_iUnitService, _iUnitRepository)
        {

        }
    }
}
