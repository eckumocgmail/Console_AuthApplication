using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Label("Артериальное давление")] 
[Units("бар")]
public class PressureIndicator: BusinessIndicator
{
    [InputNumber( )]
    public float IndValue { get; set; }
}
