using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    public class DBHelper
    {
        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        private const string TABLENAME = " item ";//테이블명
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
        //테이블에 있는 데이터 읽어들이는 메서드


        //디폴트 매개변수(일종의 오버로딩)
        //selectQuery(); 이렇게 호출하면 fn에 "1"이 자동으로 할당됨
        //selectQuery("5"); 이렇게 호출하면 fn에 "5"가 할당됨
        
        public static void selectQuery(string itemNum = "1")
        {
            try
            {
                ConnectDB();//DB연결
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (itemNum.Equals("1"))
                    cmd.CommandText = $"SELECT * FROM {TABLENAME} ORDER BY CONVERT(INT, item_num)";
                else
                    cmd.CommandText = $"SELECT * FROM {TABLENAME} WHERE item_num='{itemNum}' ORDER BY CONVERT(INT, item_num)";
                da = new SqlDataAdapter(cmd); //쿼리문을 활용하여 데이터 불러오는 것
                ds = new DataSet();
                da.Fill(ds, TABLENAME); //ds에 테이블을 채워넣음
                dt = ds.Tables[0];//만약 여러개의 테이블을 불러왔다면 그 중 첫번째꺼 갖고옴
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();//DB 연결이 잘못되더라도 연결 끊어주는 건 꼭 해줌
            }
        }
        public static void searchQuery(string searchKeyword = "")
        {
            try
            {
                ConnectDB(); // 데이터베이스 연결
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // 검색어가 제공된 경우 해당 검색어를 사용한 쿼리를 생성
                if (string.IsNullOrEmpty(searchKeyword))
                    cmd.CommandText = "select * from " + TABLENAME;
                else
                    cmd.CommandText = $"select * from {TABLENAME} where item_name like '%{searchKeyword}%'";

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, TABLENAME);
                dt = ds.Tables[0];

                // 행의 수를 확인하기 위한 출력
                Console.WriteLine($"Rows Count in selectQuery: {dt.Rows.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in selectQuery: {ex.Message}");
            }
            finally
            {
                conn.Close(); // 데이터베이스 연결 닫기
            }
        }

        public static void updateQuery(string item_num, string item_name, string item_kind, int item_price, bool isRemove)    
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string sql = "";
                if (isRemove)
                {
                    sql = $"update {TABLENAME} set item_name ='', " +
                        $"item_kind ='', item_price ='', " +
                        $"where item_num = @p1";
                    // sql injection : 해킹 방지
                    cmd.Parameters.AddWithValue("@p1", item_num);
                }
                else
                {
                    sql = $"update {TABLENAME} set item_name = @p1," +
                        $"item_kind = @p2" +
                        $"item_price = @p3 where " +
                        $"item_num = @p4";
                    cmd.Parameters.AddWithValue("@p1", item_name);
                    cmd.Parameters.AddWithValue("@p2", item_kind);
                    cmd.Parameters.AddWithValue("@p3", item_price);
                    cmd.Parameters.AddWithValue("@p4", item_num);
                }
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DataManager.printLog("update," + e.Message + e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        private static void executeQuery(string itn, string cmd)
        {
            string command = "";
            if (cmd.Equals("insert"))
            {
                command = $"insert into {TABLENAME} (item_num) values (@p1)";
            }
            else
            {
                command = $"delete from {TABLENAME} where item_num = @p1";
            }
            try
            {
                ConnectDB();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = conn;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@p1", itn);
                sqlcmd.CommandText = command;
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DataManager.printLog(cmd + "," + e.Message + "\n" + e.StackTrace);
            }
            finally { conn.Close(); }
        }
        public static void deleteQuery(string itn)
        {
            executeQuery(itn, "delete");
        }
        public static void intsertQuery(string itn)
        {
            executeQuery(itn, "insert");
        }
    }
}
