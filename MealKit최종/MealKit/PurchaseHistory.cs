using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    public class PurchaseHistory
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Item_Name { get; set; }
        public int Payment { get; set; }
        public int Contain_Item_Cnt { get; set; }

        public override string ToString()
        {
            return $"ID:{UserID}, 이름:{Name}, 주문 목록 : {Item_Name}, 주문 액 : {Payment}, 주문 수량 : {Contain_Item_Cnt}";
        }
    }
}
