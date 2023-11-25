using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    public class UserInformation
    {
        public string ID { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string DetailAddress { get; set; }
        public string ReferenceAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AccountDate { get; set; }
        public string CurrentState { get; set; }

    }
}
