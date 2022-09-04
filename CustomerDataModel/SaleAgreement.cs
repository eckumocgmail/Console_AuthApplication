








using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAnalitics
{
    public class SaleAgreement:DictionaryTable
    {
        public int ID { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
