using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MealKit
{
    public class HistoryData
    {
        //public static PurchaseHistory purchaseUser = null;

        public static List<PurchaseHistory> purchaseUsers = new List<PurchaseHistory>();

        public static void HistoryLoad(string id)
        {
            try
            {
                //select * from KitManager;
                DBPurchaseHistyory.selectQuery(id);//전체 조회를 한다.
                purchaseUsers.Clear();
                foreach (DataRow item in DBPurchaseHistyory.dt.Rows)
                {
                    PurchaseHistory pHistory = new PurchaseHistory();
                    //kit.item_num = item["item_num"].ToString();
                    pHistory.UserID = item["id"].ToString();
                    pHistory.Name = item["name"].ToString();
                    pHistory.Item_Name = item["ItemName"].ToString();
                    pHistory.Payment = int.Parse(item["payment"].ToString());
                    pHistory.Contain_Item_Cnt = int.Parse(item["containItemCnt"].ToString());
                    purchaseUsers.Add(pHistory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void Save(string id,string name, string itemName,int containItemCnt,int payment)
        {

            
            //purchaseUser = new PurchaseHistory();
            //purchaseUser.Item_Name = DBPurchaseHistyory.dt.Rows[0]["ItemName"].ToString();
            //purchaseUser.Contain_Item_Cnt = (int)DBPurchaseHistyory.dt.Rows[0]["containItemCnt"];
            //purchaseUser.Payment = (int)DBPurchaseHistyory.dt.Rows[0]["payment"];


            DBInsert(id, name, itemName, containItemCnt, payment);
        }

        private static void DBInsert(string id, string name, string itemName, int containItemCnt, int payment)
        {
            DBPurchaseHistyory.insertQuery(id, name, itemName, containItemCnt, payment);
            
        }
    }
}
