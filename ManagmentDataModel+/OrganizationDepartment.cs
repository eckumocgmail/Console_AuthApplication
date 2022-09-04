


using Newtonsoft.Json;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managment.DataModel
{

}
/// <summary>
/// Даталогическая модель сущности "Подразделение".
/// </summary>
[Label("Подразделение")]
[SearchTerms(nameof(Name) + "," + nameof(Description))]
public class OrganizationDepartment : NamedObject
{

 

    public OrganizationDepartment()
    {
        Employees = new List<Employee>();
    }

    [Label("Организация")]
    public int OrganizationID { get; set; } 

    [Label("Организация")]        
    public virtual ManagmentOrganization Organization { get; set; }


    [Label("Сотрудники")]
    [JsonIgnore]

    public virtual List<Employee> Employees { get; set; }





}
