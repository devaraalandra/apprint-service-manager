using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_G18_Final_Assignment_APPrint
{

    public partial class Assignment
    {
        public string AssignmentID { get; set; }
        public int RequestID { get; set; }
        public string WorkerID { get; set; }
        public Nullable<System.DateTime> DateAssigned { get; set; }

        public virtual Request Request { get; set; }
    }
}
