
using Managment.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
[Label("Обособленные подразделения")]
public class SeparatedDepartment<TOrganization> : NamedObject where TOrganization: ManagmentOrganization
{
   

    public SeparatedDepartment()
    {
        Employees = new List<Employee>();
    }

    [Label("Организация")]
    public int OrganizationID { get; set; } 

    [Label("Организация")]
    public virtual TOrganization Organization { get; set; }


    [Label("Сотрудники")]
    public virtual List<Employee> Employees { get; set; }
 


    [Label("Физический адрес")]
    public int LocationID { get; set; }

    [Label("Физический адрес")]
    public virtual ManagmentLocation Location { get; set; }


    [Label("Помещения")]
    public virtual List<MedicalRoom> Rooms { get; set; }
}