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

        public string GetNewCode(string Prefix, ref int Value)
        {
            using (this._dbConnection = new MySqlConnection(this.connectionString))
            {
                var sqlCommand = "Proc_GetMaxCode";
                var param = new DynamicParameters();
                param.Add("m_Prefix", Prefix);
                param.Add("m_Value", Value, null, ParameterDirection.Output);
                param.Add("m_Length", 0, null, ParameterDirection.Output);
                param.Add("m_Table", "Menu");
                var maxValue = this._dbConnection.QueryFirstOrDefault<string>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                Value = param.Get<int>("m_Value");
                return maxValue;
            }
        }

        public int InsertNewPrefix(string newPrefix, int value)
        {
            using (this._dbConnection = new MySqlConnection(this.connectionString))
            {
                var sqlCommand = "Proc_InsertPrefix";
                var param = new DynamicParameters();
                param.Add("m_Prefix", newPrefix);
                param.Add("m_Value", value);
                var res = this._dbConnection.QueryFirstOrDefault<int>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public int UpDatePrefix(string prefix, int value)
        {
            using (this._dbConnection = new MySqlConnection(this.connectionString))
            {
                var sqlCommand = "Proc_UpdatePrefix";
                var param = new DynamicParameters();
                param.Add("m_Prefix", prefix);
                param.Add("m_Value", value);
                param.Add("m_Table", "Menu");
                var res = this._dbConnection.QueryFirstOrDefault<int>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion
    }
}
