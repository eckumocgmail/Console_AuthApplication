using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



[Label("Показатель уровня кислорода в крови")]
public class OxygenInBloor: BusinessIndicator
{

    [NotNullNotEmpty()]
    public float Value { get; set; }
}