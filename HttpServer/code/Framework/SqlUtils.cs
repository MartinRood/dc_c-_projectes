using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HttpHandle
{
    public class SQLUtils
    {
        private static SqlConnection dbConnection;
        private static Log dbLog;
        private static bool isOpen = false;

        public static void OpenSqlConnection()
        {
            if (isOpen) return;
            dbLog = new Log(LogType.Weekly);

            string str_conn = "server=.;database=ocean;uid=sa;pwd=root;MultipleActiveResultSets=true";
            dbLog.Write("请求打开连接:" + str_conn, MsgType.Information);
            try
            {
                dbConnection = new SqlConnection(str_conn);
                dbConnection.Open();
            }
            catch(Exception e)
            {
                dbLog.Write("打开连接失败:" + e.Message, MsgType.Error);
                return;
            }
            dbLog.Write("打开连接成功:" + str_conn, MsgType.Information);
            isOpen = true;
        }

        public static void CloseSqlConnection()
        {
            isOpen = false;
            dbConnection.Close();
            dbConnection = null;
            dbLog.Write("关闭连接", MsgType.Information);
        }

        public static bool FindScore(string sign, ref int score)
        {
            OpenSqlConnection();
            using(SqlCommand dbCommand = dbConnection.CreateCommand())
            {

                dbCommand.CommandText = "Select * From character where sign =@sign";
                dbCommand.Parameters.Add(new SqlParameter("@sign", sign));
                SqlDataReader quesReader = dbCommand.ExecuteReader();
                if(!quesReader.HasRows)
                {
                    dbCommand.Dispose();
                    return false;
                }

                quesReader.Read();
                score = (int)quesReader["score"];
                dbCommand.Dispose();
                return true;
            }
        }

        //public static List<RankInfo> GetRankList(int count)
        //{
        //    OpenSqlConnection();
        //    List<RankInfo> list = new List<RankInfo>();

        //    using (SqlCommand dbCommand = dbConnection.CreateCommand())
        //    {
        //        dbCommand.CommandText = "Select * From character";
        //        SqlDataReader quesReader = dbCommand.ExecuteReader();
        //        while (quesReader.HasRows)
        //        {
        //            quesReader.Read();
        //            RankInfo info = new RankInfo();
        //            info.id = (string)quesReader["sign"];
        //            info.name = (string)quesReader["name"];
        //            info.score = (int)quesReader["score"];
        //            info.rank = 0;
        //            list.Add(info);
        //        }

        //        dbCommand.Dispose();
        //    }

        //    return list;
        //}

        /// <summary>
        /// 插入新记录
        /// </summary>
        public static void InsertCharacter(string sign, string name, int score)
        {
            OpenSqlConnection();
            string sqlInsert = "Insert Into character VALUES(" + "'" + sign + "'," + "'" + name + "'," + score + ")";
            DoQuery(sqlInsert);
            dbLog.Write("插入新记录："+sign + " name:" + name, MsgType.Information);
        }

        public static void UpdateScore(string sign, int score)
        {
            OpenSqlConnection();
            string sqlInsert = "Update character set score=" + score + " Where sign='" + sign + "'";
            DoQuery(sqlInsert);
            dbLog.Write("更新记录：" + sign, MsgType.Information);
        }

        private static void DoQuery(string strCommand)
        {
            using(SqlCommand dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = strCommand;
                int i = dbCommand.ExecuteNonQuery();
                if(i == 0)
                {
                    Console.WriteLine("执行失败:" + strCommand);
                }
                dbCommand.Dispose();
            }
        }
    }
}