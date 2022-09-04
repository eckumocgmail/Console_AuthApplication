using ApplicationDb.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Icon("person")]
[Label("Медицинская карта")]
[ClassDescription("Медицинская карта")]
public class MedicalCard : ActiveObject
{

    [Label("Страховой мед. полис")]
    public string Policy { get; set; }


    [NotNullNotEmpty("Личные данные")]
    public int PersonID { get; set; }
    public virtual UserPerson Person { get; set; }


    [NotNullNotEmpty("История болезни")]
    public virtual List<MedicalCase> MedicalCase { get; set; }
}