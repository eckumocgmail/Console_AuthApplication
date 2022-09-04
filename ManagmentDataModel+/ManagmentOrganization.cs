

using Managment.DataModel;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Label("Организация")]
public class ManagmentOrganization : DictionaryTable 
{

    [Label("ИНН")]
    public string INN { get; set; }

    [Label("Юридический адрес")]
    public int JuristicalLocationID { get; set; }

    [Label("Юридический адрес")]
    public virtual ManagmentLocation JuristicalLocation { get; set; }


    [Label("Обособленные подразделения")]
    [JsonIgnore]
    public List<OrganizationDepartment> ManagmentDepartments { get; set; }


    
}