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
    /// <summary>
    /// Repository dùng chung cho các đối tượng
    /// </summary>
    /// created by ndluc(07/07/2021)
    public class BaseRepository<MISAEntities> : IBaseRepository<MISAEntities> where MISAEntities :BaseEntity
    {

        #region Properties
        IConfiguration _iConfigruation;
        protected string connectionString;
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration iConfiguration)
        {
            _iConfigruation = iConfiguration;
            connectionString = _iConfigruation.GetConnectionString("DefaultConnection");
        }
        #endregion
        public int DeleteById(Guid id, string tableDelete=null, string property = null)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                if (tableDelete != null)
                {
                    name = tableDelete;
                }
                var propertyName = typeof(MISAEntities).Name;
                if(property != null)
                {
                    propertyName = property;
                }
                var param = new DynamicParameters();
                param.Add($"m_{propertyName}Id", id.ToString());
                var SqlCommand = $"Proc_Delete{name}";
                var res = _dbConnection.Execute(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public virtual MISAEntities GetById(Guid id)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {

                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                param.Add($"m_{name}Id", id.ToString());
                var SqlCommand = $"Proc_Get{name}ById";
                var entity = _dbConnection.QueryFirstOrDefault<MISAEntities>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public string GetNewCode()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MISAEntities> GetPaging(int PageSize, int PageNumber, string WhereClause, string Sort , ref int TotalRecord)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var SqlCommand = $"Proc_GetPaging{name}s";
                var param = new DynamicParameters();
                param.Add("PageNumber", PageNumber);
                param.Add("PageSize", PageSize);
                param.Add("WhereClause", WhereClause);
                param.Add("Sort", Sort);
                var totalRecord =0;
                param.Add("TotalRecord",totalRecord ,null, ParameterDirection.Output);
                var result = _dbConnection.Query<MISAEntities>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                TotalRecord = param.Get<int>("TotalRecord");
                return result;
            }
        }

        public int Insert(MISAEntities entity)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {

                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                var SqlCommand = $"Proc_Insert{name}";
                var res = 0;
                // build param truyền vào store
                BuildParamBeforeInsertOrUpDate(param, entity);
                var returnNumber = _dbConnection.Execute(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                res += returnNumber;
                return res;
            }
        }

        public int Update(Guid id, MISAEntities entity)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var SqlCommand = $"Proc_Update{name}";
                var param = new DynamicParameters();
                BuildParamBeforeInsertOrUpDate(param, entity);
                var result = _dbConnection.Execute(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public bool CheckExists(string ValueCheck, string propertyName, string entityId = null)
        {
            using (_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                var param = new DynamicParameters();
                param.Add($"m_{propertyName}", ValueCheck);
                param.Add($"m_{name}Id", entityId);
                var SqlCommand = $"Proc_Check{name}{propertyName}Exists";
                var res = _dbConnection.QueryFirstOrDefault<bool>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        /// <summary>
        /// build param truyền vào cho store trước khi thêm hoặc sửa
        /// </summary>
        /// <param name="param">param cần build để truyền vào</param>
        /// <param name="entity">đối tượng cần đưa dữ liệu vào</param>
        /// created by ndluc(08/07/2021)
        private void BuildParamBeforeInsertOrUpDate(DynamicParameters param, MISAEntities entity)
        {
            var properties = typeof(MISAEntities).GetProperties();
            foreach(var property in properties)
            {
                param.Add($"m_{property.Name}", property.GetValue(entity));
            }
        }

        public IEnumerable<MISAEntities> GetAll()
        {
            using(_dbConnection = new MySqlConnection(connectionString))
            {
                var nameOfObject = typeof(MISAEntities).Name;
                var sqlCommand = $"Proc_Get{nameOfObject}";
                var res = _dbConnection.Query<MISAEntities>(sqlCommand, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public int InsertList(List<MISAEntities> listEntities, string tableName = null)
        {
            using(_dbConnection = new MySqlConnection(connectionString))
            {
                var name = typeof(MISAEntities).Name;
                if(tableName != null)
                {
                    name = tableName;
                }
                var numberInsert = 0;
                var sqlCommand = $"Proc_Insert{name}";
                foreach (var entity in listEntities)
                {
                    var param = new DynamicParameters();
                    BuildParamBeforeInsertOrUpDate(param, entity);
                    var res = _dbConnection.Execute(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                    numberInsert += res;
                }
                return numberInsert;
            }
        }
    }
}
    