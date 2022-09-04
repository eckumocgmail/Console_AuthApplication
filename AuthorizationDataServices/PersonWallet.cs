using ApplicationDb.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel.Model.BankDataModel
{
    [Label("Валюта")]
    public class CurrencyUnit : DictionaryTable 
    {
    }

    [Label("Сумма денежных средств")]
    public class CurrencyModel : BaseEntity
    {
        public float CurrencyValue { get; set; }
        public int CurrencyUnitID { get; set; }
        public virtual CurrencyUnit CurrencyUnit { get; set; }

    }
   


    



    public class PersonWallet: CurrencyModel
    {            
        public int UserID { get; set; }
        public UserContext User { get; set; }

    }

    public class OrgWallet: PersonWallet
    {
        public int OrganizationID { get; set; }
        public ManagmentOrganization Organization { get; set; }
    }
}
