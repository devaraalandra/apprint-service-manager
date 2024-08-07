using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class WorRequest
    {
        public WorRequest()
        {
            this.Assignments = new HashSet<Assignment>();
        }

        public int RequestID { get; set; }
        public string Username { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public Nullable<decimal> TotalFee { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Urgency { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
