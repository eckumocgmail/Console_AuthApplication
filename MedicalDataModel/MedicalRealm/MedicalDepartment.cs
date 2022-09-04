using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Label("Медицинское подразделение")]
public partial class MedicalDepartment : OrganizationDepartment 
{



    /// <summary>
    /// Способ оказания медицинской помощи
    /// </summary>
    [Select("Amb,Host,LabDepartment")]
    [NotNullNotEmpty()]
    public string MedicalType { get; set; } = "Amb";


}