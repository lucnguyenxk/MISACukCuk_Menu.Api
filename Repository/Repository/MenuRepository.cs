using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Services.Entities;
using Services.Interfaces.IRespository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        IBaseRepository<ServiceHobby> iServiceHobbyRepository;
        #region Constructor
        public MenuRepository(IConfiguration iConfigruation, IBaseRepository<ServiceHobby> _iServiceHobbyRepository) : base(iConfigruation)
        {
            iServiceHobbyRepository = _iServiceHobbyRepository;
        }
        #endregion
        #region Methods
        public override Menu GetById(Guid id)
        {
            var menuEntity = base.GetById(id);
            if(menuEntity != null)
            {
                using (this._dbConnection = new MySqlConnection(this.connectionString))
                {
                    var paramMenu = new DynamicParameters();
                    paramMenu.Add("m_MenuId", id);
                    var sqlCommand = "Proc_GetServiceHobbyById";
                    menuEntity.ListServiceHobby = this._dbConnection.Query<ServiceHobby>(sqlCommand, param: paramMenu, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return menuEntity;
            
        }
        #endregion
    }
}
