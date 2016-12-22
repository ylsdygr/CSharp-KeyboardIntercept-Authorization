using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ForAuthorization
{
    public class DatabaseOperator
    {
        public String mysqlInfo = String.Empty;  //数据库连接信息总串
        protected String para_DatabaseIP = String.Empty;  //数据库连接IP
        protected String para_DatabaseUser = String.Empty;  //数据库连接用户名
        protected String para_DatabasePWD = String.Empty;  //数据库连接密码
        protected String para_DatabaseName = String.Empty;  //数据库名称
        protected String para_DatabasePort = String.Empty;  //数据库端口
        public DatabaseOperator()
        {
        }
        /// <summary>
        /// 数据库初始化构造函数
        /// </summary>
        /// <param name="DatabaseIP"></param>
        /// <param name="DatabaseUser"></param>
        /// <param name="DatabasePWD"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="DatabasePort"></param>
        public DatabaseOperator(string DatabaseIP, string DatabaseUser, string DatabasePWD, string DatabaseName, string DatabasePort)
        {
            this.para_DatabaseIP = DatabaseIP;
            this.para_DatabaseUser = DatabaseUser;
            this.para_DatabasePWD = DatabasePWD;
            this.para_DatabaseName = DatabaseName;
            this.para_DatabasePort = DatabasePort;
            this.mysqlInfo = "server=" + this.para_DatabaseIP + ";User ID=" + this.para_DatabaseUser +
                 ";password=" + this.para_DatabasePWD + ";Database=" + this.para_DatabaseName + ";Port=" + DatabasePort + ";";
        }
        /// <summary>
        /// 向数据库添加授权
        /// </summary>
        /// <param name="insertString"></param>
        /// <returns></returns>
        public int insertAuthorizedKeyToMysqlDatabase(string insertString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(mysqlInfo);
                MySqlDataAdapter insertAdapter = new MySqlDataAdapter();
                MySqlCommand insertExecution = new MySqlCommand(insertString, connection);
                insertAdapter.InsertCommand = insertExecution;
                connection.Open();
                if (!(connection.State == ConnectionState.Open)) { return 0; }
                int insertResult = insertAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                //connection.ClearPoolAsync(connection);
                if (insertResult > 0)
                {
                    return 1;
                }
            }
            catch (Exception ex) { return 0; }
            return 0;
        }
    }
}
