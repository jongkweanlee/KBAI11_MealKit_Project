using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    public class DBPurchaseHistyory
    {
        //DB 연결 및 테이블 데이터 다룰 때 필요한 객체들
        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        private const string TABLENAME = " PurchaseHistory ";//테이블명

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

        public static void selectQuery(string id = "")
        {
            try
            {
                ConnectDB();//DB연결
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (id.Equals(""))
                    cmd.CommandText = $"SELECT * FROM {TABLENAME} ORDER BY rownum";
                else
                    cmd.CommandText = $"SELECT * FROM {TABLENAME} WHERE id='{id}' ORDER BY rownum";
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



        private static void executeQuery(string id, string name, string itemName, int containItemCnt, int payment)
        {
            string command = "";
            command = $"insert into {TABLENAME} values ((@id), (@name), (@itemName), (@containItemCnt), (@payment))";

            try
            {
                ConnectDB();
                SqlCommand sqlcmd = new SqlCommand(command);
                sqlcmd.Connection = conn;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@id", id);
                sqlcmd.Parameters.AddWithValue("@name", name);
                sqlcmd.Parameters.AddWithValue("@itemName", itemName);
                sqlcmd.Parameters.AddWithValue("@containItemCnt", containItemCnt);
                sqlcmd.Parameters.AddWithValue("@payment", payment);
                sqlcmd.CommandText = command;
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { }
            finally { conn.Close(); }
        }


        public static void insertQuery(string id, string name, string itemName, int containItemCnt, int payment)
        {
            executeQuery(id, name, itemName, containItemCnt, payment);
        }
    }
}
