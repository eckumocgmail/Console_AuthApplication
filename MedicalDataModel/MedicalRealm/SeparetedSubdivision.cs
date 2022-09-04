using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel.DataSource.DataModels.MediсalDataModel
{
    public class SeparetedSubdivision: BaseEntity
    {

        [DisplayName("Организация")]
        public int MedOrganizationID { get; set; }
        public virtual MedicalOrganization MedOrganization { get; set; }


 



        // физический адрес тогрговой точки
        public string Location { get; set; }
    }
}
