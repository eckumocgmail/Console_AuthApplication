

using Microsoft.EntityFrameworkCore;



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[LabelAttribute("Профеccиональные навыки")]
[SearchTermsAttribute(nameof(Name) + "," + nameof(Description))]
public class SKillExpirience : DictionaryTable 
{

    public virtual List<EmployeeExpirience> Expirience { get; set; }
}