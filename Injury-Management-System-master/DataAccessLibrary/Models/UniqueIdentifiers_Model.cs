using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class UniqueIdentifiers_Model
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public DateTime Date_of_Injury { get; set; }
        public string UUID { get; set; }
    }
}
