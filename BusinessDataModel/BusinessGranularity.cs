using System;
using System.Collections.Generic;
using System.Text;


[Label("Паралельность(периодичность)")]
[SystemEntity()]
public class BusinessGranularities : DictionaryTable 
{


    [UniqValidation()]
    public string Code { get; set; }

}