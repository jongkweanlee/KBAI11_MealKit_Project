using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    public class DBManagerClientInfor
    {
        //DB 연결 및 테이블 데이터 다룰 때 필요한 객체들
        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        private const string TABLENAME = " AccountManager ";//테이블명
        //DB 연결하는 메서드
        private static void ConnectDB()
        {
            string dataSource = "local";
            string db = "KitManager"; //DB명
            string security = "SSPI";
            conn.ConnectionString =
                $"Data Source=({dataSource}); initial Catalog={db};" +
                $"integrated Security={security};" +
                "Timeout=3";
            conn.Open();

        }
        //테이블에 있는 데이터 읽어
        //가입을 할 때 중복확인하는 메서드
        //중복되는 ID는 생성불가
        public static void SelectQuery(string id = "-1")
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (id.Equals("-1"))
                    cmd.CommandText = "select * from + " + TABLENAME;
                else
                    cmd.CommandText = $"select * from {TABLENAME} where UserID='{id}'";
                da = new SqlDataAdapter(cmd);//쿼리문 활용하여 데이터 불러오는 것
                ds = new DataSet();
                da.Fill(ds, TABLENAME);//ds에 테이블을 채워넣음
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                UserDataManager.UserAccountLog("select");
                UserDataManager.UserAccountLog(ex.Message);
                UserDataManager.UserAccountLog(ex.StackTrace);
            }
            finally { conn.Close(); }
        }

        // 가입한 유저가 로그인할 때 쓰일 쿼리문
        public static void SelectQuery(string id = "-1", string pw = "-1")
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (id.Equals("-1") && pw.Equals("-1"))
                    cmd.CommandText = "select * from + " + TABLENAME;
                else
                    cmd.CommandText = $"select * from {TABLENAME} where " +
                        $"UserID='{id}' and UserPW='{pw}'";
                da = new SqlDataAdapter(cmd);//쿼리문 활용하여 데이터 불러오는 것
                ds = new DataSet();
                da.Fill(ds, TABLENAME);//ds에 테이블을 채워넣음
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {
                UserDataManager.UserAccountLog("select");
                UserDataManager.UserAccountLog(ex.Message);
                UserDataManager.UserAccountLog(ex.StackTrace);
            }
            finally { conn.Close(); }
        }

        // 유저의 로그인 또는 로그아웃 상태에 쓰일 쿼리문
        public static void updateQuery(string id, string pw, string currrentState)
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string sql = "";
                sql = $"update {TABLENAME} set currentstate=@p1 where " +
                    $"userid=@p2 and userpw=@p3";
                cmd.Parameters.AddWithValue("@p1", currrentState);
                cmd.Parameters.AddWithValue("@p2", id);
                cmd.Parameters.AddWithValue("@p3", pw);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                UserDataManager.CurrentStateLog("update," + e.Message + e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        private static void executeQuery(string id, string pw, string name, string zipCode, string adress, string detailAdress,
            string referenceAdress, string phoneNumber, string cmd)
        {
            string command = "";
            if (cmd.Equals("insert"))
            {
                command = $"insert into {TABLENAME} values ((@p1), (@p2), (@p3), (@p4), (@p5), (@p6), (@p7), (@p8), (@p9), (@p10))";
                try
                {
                    ConnectDB();
                    SqlCommand sqlcmd = new SqlCommand(command);
                    sqlcmd.Connection = conn;
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.Parameters.AddWithValue("@p1", id);
                    sqlcmd.Parameters.AddWithValue("@p2", pw);
                    sqlcmd.Parameters.AddWithValue("@p3", name);
                    sqlcmd.Parameters.AddWithValue("@p4", zipCode);
                    sqlcmd.Parameters.AddWithValue("@p5", adress);
                    sqlcmd.Parameters.AddWithValue("@p6", detailAdress);
                    sqlcmd.Parameters.AddWithValue("@p7", referenceAdress);
                    sqlcmd.Parameters.AddWithValue("@p8", phoneNumber);
                    sqlcmd.Parameters.AddWithValue("@p9", DateTime.Now.ToString(
                        "yyyy-MM-dd HH:mm:ss.fff"));
                    sqlcmd.Parameters.AddWithValue("@p10", "");
                    sqlcmd.CommandText = command;
                    sqlcmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    UserDataManager.UserAccountLog(cmd + "," + e.Message + "\n" + e.Message);
                }
                finally { conn.Close(); }
            }

        }

        //유저 삭제
        private static void executeQuery(string id, string cmd)
        {
            string command = "";
            command = $"delete from {TABLENAME} where UserID=(@p1)";
            try
            {
                ConnectDB();
                SqlCommand sqlcmd = new SqlCommand(command);
                sqlcmd.Connection = conn;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@p1", id);
                sqlcmd.CommandText = command;
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                UserDataManager.CurrentStateLog(cmd + "," + e.Message + "\n" + e.Message);
            }
        }

        public static void deleteQurey(string id, string cmd)
        {
            executeQuery(id, cmd);
        }

        public static void updateQuery(string id, string pw, string name, string zipCode, string adress,
            string detailAdress, string referenceAdress, string phoneNumber, string cmd)
        {
            executeQuery(id, pw, name, zipCode, adress, detailAdress, referenceAdress, phoneNumber, cmd);
        }
        public static void insertQuery(string id, string pw, string name, string zipCode, string adress,
            string detailAdress, string referenceAdress, string phoneNumber)
        {
            executeQuery(id, pw, name, zipCode, adress, detailAdress, referenceAdress, phoneNumber, "insert");
        }

    }
}
