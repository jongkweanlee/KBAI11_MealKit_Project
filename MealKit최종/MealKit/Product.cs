using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    public class Product
    {
        public string item_num { get; set; }
        public string item_name { get; set; } 
        public string item_kind { get; set; }
        public int item_price { get; set; }
        public string item_date { get; set; }
        public int item_cnt { get; set;}         
    }
}
