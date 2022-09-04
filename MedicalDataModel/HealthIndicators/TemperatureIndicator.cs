using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConstructor.Shared.HealthIndicators
{
    [Description(@"
        Абсолютный ноль	                            0 K	        −273,15 °C	    −459,67 °F
        Температура кипения жидкого азота	        77,4 K	    −195,8 °C[11]	−320,3 °F
        Сублимация (переход из твёрдого 	        195,1 K	    −78 °C	        −108,4 °F
            состояния в газообразное) сухого льда
        Точка пересечения шкал Цельсия и Фаренгейта	233,15 K	−40 °C	        −40 °F
        Температура плавления льда	                273,1499 K	−0,0001 °C[12]	31,99982 °F
        Тройная точка воды	                        273,16 K	0,01 °C	        32,018 °F
        Нормальная температура человеческого тела[13]	310 K	36,6 °C	        97,9 °F
        Температура кипения воды при давлении в 1 атмосферу (101,325 кПа)	373,1339 K	99,9839 °C[12]	211,971 °F
    ")]
    public class TemperatureIndicator: BusinessIndicator
    {
 
        [Units("C")]
        [Label("Значение в цельсиях")]
        [NotNullNotEmpty("Значение определено во множействе действительных чисел")]
        public float Digrees { get; set; }
        public DateTime BeginDate { get; set; }


        public TemperatureIndicator(float Digrees, DateTime BeginDate)
        {
            this.BeginDate = BeginDate;
            this.Digrees = Digrees;
        }
 

         
    }
}
