using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using UserProfileUpdate.Models.InputModel;
using UserProfileUpdate.Models.ViewModel;

namespace UserProfileUpdate.Services
{
    public class UserService : IUserService
    {
        IConfiguration configuration;
        public UserService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        //Retrive Users by their User ID
        public object GetUserById(int userId)
        {
            object result = null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("U_USER_ID", OracleDbType.Int32, ParameterDirection.Input, userId);
                dyParam.Add("USER_ID_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "USP_GETUSERBYID";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
                conn.Close();
            return result;
        }

        //Retrive Users by their User Nem
        public object GetUserByUserName(string userName)
        {
            object outputResult=null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("u_user_name", OracleDbType.Varchar2, ParameterDirection.Input,userName);
                dyParam.Add("USER_NAME_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "usp_getuserbyUserName";
                    outputResult = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
                conn.Close();
            return outputResult;
        }

        //Retrive Users by their Email ID
        public object GetUserByEmailId(string email_Id)
        {
            object outputResult = null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("u_email_id", OracleDbType.Varchar2, ParameterDirection.Input, email_Id);
                dyParam.Add("user_emailid_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "usp_getuserbyemailid";
                    outputResult = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
                conn.Close();
            return outputResult;
        }

        //Retrive All Users 
        public object GetAllUsers()
        {
            object result = null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("USER_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "USP_GETUSERDETAILS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
                conn.Close();
            return result;
        }

        //Adding Users
        public object AddUser(UserViewModel userViewModel)
        {
            object result = null, outputResult = null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("U_FIRST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, userViewModel.firstName);
                dyParam.Add("U_LAST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, userViewModel.lastName);
                dyParam.Add("U_USER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, userViewModel.userName);
                dyParam.Add("U_PASSWORD", OracleDbType.Varchar2, ParameterDirection.Input, userViewModel.password);
                dyParam.Add("U_EMAIL_ID", OracleDbType.Varchar2, ParameterDirection.Input, userViewModel.email_Id);
                dyParam.Add("u_user_groups_id", OracleDbType.Int32, ParameterDirection.Input, userViewModel.userGroupId);
                dyParam.Add("u_user_id", OracleDbType.Int32, ParameterDirection.Output);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "USP_ADDUSER";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    outputResult = GetUserByUserName(userViewModel.userName);
                }
                conn.Close();
            return outputResult;
        }

        //Update Users information
        //can't userID
        public object UpdateUser(UserInputModel userInputModel)
        {
            object result = null, resultData = null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

                var dyParam = new OracleDynamicParameters();
                dyParam.Add("u_user_id", OracleDbType.Int32, ParameterDirection.Input, userInputModel.userId);
                dyParam.Add("U_FIRST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, userInputModel.firstName);
                dyParam.Add("U_LAST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, userInputModel.lastName);
                dyParam.Add("U_USER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, userInputModel.userName);
                dyParam.Add("U_PASSWORD", OracleDbType.Varchar2, ParameterDirection.Input, userInputModel.password);
                dyParam.Add("U_EMAIL_ID", OracleDbType.Varchar2, ParameterDirection.Input, userInputModel.email_Id);
                dyParam.Add("u_user_groups_id", OracleDbType.Int32, ParameterDirection.Input, userInputModel.userGroupId);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "USP_UPDATEUSER";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    resultData = GetUserById(userInputModel.userId);
                }
                conn.Close();
            return resultData;
        }

        //Delete Users information by their Id
        public object DeleteUser(int userId)
        {
            object result = null, resultData = null;
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("U_USER_ID", OracleDbType.Int32, ParameterDirection.Input, userId);

                if (conn.State == ConnectionState.Open)
                {
                    var query = "USP_DELETEUSER";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    resultData = "User with User ID " + userId + " Deleted successfully";
                }
               conn.Close();
            return resultData;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("UserConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
