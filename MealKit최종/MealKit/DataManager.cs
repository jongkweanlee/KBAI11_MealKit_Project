using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{   
    public class DataManager
    {
        public static List<Product> products = new List<Product>();
        public static List<User> users = new List<User>();

        
        static DataManager()
        {
            KitLoad();
        }

        public static void KitLoad()
        {
            try
            {
                //select * from KitManager;
                DBHelper.selectQuery();//전체 조회를 한다.
                products.Clear();
                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    Product kit = new Product();
                    kit.item_num = item["item_num"].ToString();
                    kit.item_name = item["item_name"].ToString();
                    kit.item_date = item["item_date"].ToString();
                    kit.item_cnt = Convert.ToInt32(item["item_cnt"]);
                    kit.item_price = Convert.ToInt32(item["item_price"]);
                    kit.item_kind = item["item_kind"].ToString();                  
                    products.Add(kit);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        public static void UserLoad()
        {
            try
            {
                //select * from KitManager;
                DBHelper.selectQuery();//전체 조회를 한다.
                users.Clear();
                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    User account = new User();
                    account.Id = item["Id"].ToString();
                    account.NickName = item["NickName"].ToString();
                    account.Email = item["Email"].ToString();
                    account.Password = item["Password"].ToString();
                    account.UserName = item["UserName"].ToString();
                    account.Address = item["Address"].ToString();
                    account.PhoneNum = item["PhoneNum"].ToString();
                    users.Add(account);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        public static void Save(string item_num, string item_name, string item_kind, int item_price, bool isRemove = false)
        {
            try
            {
                DBHelper.updateQuery(item_num, item_name, item_kind, item_price, isRemove);
            }
            catch (Exception)
            {

            }
        }

        // 주차공간 추가 삭제
        public static bool Save(string cmd, string item_num, out string contents)
        {
            DBHelper.selectQuery(item_num);

            contents = "";
            if (cmd.Equals("insert"))
            {
                return DBInsert(item_num, ref contents);
            }
            else
            {
                return DBDelete(item_num, ref contents);
            }
        }
        private static bool DBInsert(string item_num, ref string contents)
        {
            if (DBHelper.dt.Rows.Count == 0)
            {
                DBHelper.intsertQuery(item_num);
                contents = $" 상품 공간 {item_num} 추가됨";
                return true;
            }
            else
            {
                contents = " 해당 공간 이미 있음";
                return false;
            }
        }
        private static bool DBDelete(string item_num, ref string contents)
        {
            if (DBHelper.dt.Rows.Count == 0)
            {
                contents = " 해당 공간 없음(삭제)";
                return false;
            }
            else
            {
                DBHelper.deleteQuery(item_num);
                contents = $" 상품 공간 {item_num} 삭제됨";
                return true;
            }
        }
        public static void printLog(string contents)
        {
            DirectoryInfo di = new DirectoryInfo("LogFolder");
            if (di.Exists == false)
            {
                di.Create();
            }
            // using :: 메모리를 할당하고 나서 다 쓰고 나면 자동으로 소멸 시켜줌
            using (StreamWriter w = new StreamWriter(@"LogFolder\MealKitHistory.txt", true))
            {
                w.WriteLine(contents);
            }
        }
    }
}
