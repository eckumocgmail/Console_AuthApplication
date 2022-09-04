using ApplicationCore.Converter;

using ApplicationDb.Entities;


using CoreModel.CoreUtils;
using EnterpriceResourcePlanin;
using AppAnalitics;

using Managment.DataModel;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{


    /// <summary>
    /// Наполняет первичными данными базу
    /// </summary>
    public class ManagmentDataInitiallizer
    {

        /// <summary>
        /// Валидация хранилища данных
        /// </summary>
        public static void InitPrimaryData()
        {
            try
            {

                using (var db = new ManagmentDataModel())
                {
                    Writing.ToConsole("\n\nИнициаллизация минимального набора данных...");

                    Data.ManagmentDataInitiallizer.InitOrganizations(db);

                    Data.ManagmentDataInitiallizer.InitPositions(db);
                    Data.ManagmentDataInitiallizer.InitDepartments(db);
                    Data.ManagmentDataInitiallizer.InitStaffs(db);
                    Data.ManagmentDataInitiallizer.InitRates(db);
                    Data.ManagmentDataInitiallizer.InitSkills(db);
                    Data.ManagmentDataInitiallizer.InitPositionFunctions(db);
                    Data.ManagmentDataInitiallizer.InitEmployees(db);

                    Data.ManagmentDataInitiallizer.InitEmployessExpirience(db);

                    Writing.ToConsole(db.Departments.ToJsonOnScreen());
                    EnsureIsValidate();
                }




            }
            catch (Exception ex)
            {
                
                Exception p = ex;
                while (p != null)
                {
                    Writing.ToConsole(p.Message);
                    p = p.InnerException;
                }

                throw;
            }

        }







        /// <summary>
        /// Регистрация "Штатного расписания"
        /// </summary>
        private static void InitPositions()
        {

            using (var db = new ManagmentDataModel())
            {
                InitPositions(db);
            }
        }

        private static void InitPositions(ManagmentDataModel db)
        {
            if (db.Positions.Count() == 0)
            {

                Writing.ToConsole("Регистрация Штатного расписания");
                db.Positions.AddRange(

                    new List<string>() {
                            "Бухгалтер",
                            "Главный бухгалтер",
                            "Главный логист",
                            "Инженер монтажник",
                            "Логист",
                            "Менеджер по продажам",
                            "Менеджер по сопровождению",

                            "Офис менеджер",
                            "Программист",
                            "Руководитель дивизиона",
                            "Старший программист"}.Select(p => new EmployeePosition() { Name = p, Description = p })
                );
                db.SaveChanges();
                db.Positions.ToList().ForEach(pos =>
                {
                    db.PositionStats.Add(new PositionStats()
                    {
                        PositionID = pos.ID,
                        RateActivatedDate = DateTime.Now,
                        RateSize = 5
                    });
                });
            }

            db.SaveChanges();

        }







        /// <summary>
        /// Регистрация сведений о сотрудниках
        /// </summary>


        private static void InitEmployees(ManagmentDataModel db)
        {
            Writing.ToConsole("Регистрация сведений о сотрудниках... ");
            if (db.Employees.Count() == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    OrganizationDepartment dep = db.Departments.GetRandom<OrganizationDepartment>();
                    EmployeePosition pos = db.Positions.GetRandom<EmployeePosition>();
                    var e = CandidateGenerator.GetEmployees();
                    e.Position = pos;
                    db.Employees.Add(e);
                    dep.Employees.Add(e);

                    db.SaveChanges();
                }
            }
        }



        /// <summary>
        /// Регистрация сведений о навыках... 
        /// </summary>

        private static void InitSkills(ManagmentDataModel db)
        {
            if (db.Skills.Count() == 0)
            {
                Writing.ToConsole("Регистрация сведений о навыках... ");
                foreach (string skill in CandidateGenerator.skills)
                {

                    db.Skills.Add(new SKillExpirience() { Name = skill, Description = skill });
                    db.SaveChanges();
                    db.PositionFunctions.Add(new PositionFunction()
                    {
                        Name = "Писать код " + skill,
                        Description = "Писать код " + skill,
                        PositionID = db.Positions.GetRandom<EmployeePosition>().ID
                    });
                    db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Получение случаного целого числа в диапозоне от нуля до заданного предела
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static int GetRandom(int max)
        {
            int res = new Random().Next(max);
            return res == 0 ? 1 : res;
        }



        /// <summary>
        /// Создание штатного расписания
        /// </summary>

        private static void InitStaffs(ManagmentDataModel db)
        {
            if (db.Staffs.Count() == 0)
            {
                Writing.ToConsole("создание штатного расписания()");
                var listOfPositions = db.Positions.ToList();
                foreach (var position in listOfPositions)
                {
                    db.Staffs.Add(new StaffsTable()
                    {
                        Department = db.Departments.GetRandom<OrganizationDepartment>(),
                        PositionID = position.ID,
                        CountOfEmployees = GetRandom(5)
                    });

                }
                db.SaveChanges();


            }
        }



        /// <summary>
        /// Запись данных о коэффициентов трудового стажа
        /// </summary>
        private static void InitRates()
        {

            using (var db = new ManagmentDataModel())
            {
                InitRates(db);
            }
        }

        private static void InitRates(ManagmentDataModel db)
        {
            if (db.TariffRates.Count() == 0)
            {
                Writing.ToConsole("Запись данных о коэффициентов трудового стажа");
                var listOfPositions = db.Staffs.Include(s => s.Position).ToList();
                foreach (var staff in listOfPositions)
                {
                    db.TariffRates.Add(new EmployeeCost()
                    {
                        Name = "Базовая",
                        Description = "Базовая ставка",
                        PositionID = staff.Position.ID
                    });

                }
                db.SaveChanges();


            }
        }





        /// <summary>
        /// Запись данных о подразделениях организации
        /// </summary>
        private static void InitDepartments()
        {

            using (var db = new ManagmentDataModel())
            {
                InitDepartments(db);
            }
        }

        private static void InitDepartments(ManagmentDataModel db)
        {
            
            if (db.Departments.Count() < 5)
            {
                Writing.ToConsole("запись данных о подразделениях....");


                int idOrganization = db.Organizations.First().ID;
                db.Departments.ToList().ForEach(p =>
                {
                    db.Departments.Remove(p);
                });
                db.SaveChanges();
                db.Add(new OrganizationDepartment()
                {
                    Name = "Администрация",
                    Description = "Администрация",
                    OrganizationID = idOrganization

                });
                db.Add(new OrganizationDepartment()
                {
                    Name = "Отдел обеспечения",
                    Description = "Отдел обеспечения",
                    OrganizationID = idOrganization
                });
                db.Add(new OrganizationDepartment()
                {
                    Name = "Отдел продаж",
                    Description = "Отдел продаж",
                    OrganizationID = idOrganization
                });
                db.Add(new OrganizationDepartment()
                {
                    Name = "Отдел развития и разработки",
                    Description = "Отдел развития и разработки",
                    OrganizationID = idOrganization
                });
                db.Add(new OrganizationDepartment()
                {
                    Name = "Отдел сопровождения",
                    Description = "Отдел сопровождения",
                    OrganizationID = idOrganization
                });
                db.Add(new OrganizationDepartment()
                {
                    Name = "Финансовый отдел",
                    Description = "Финансовый отдел",
                    OrganizationID = idOrganization
                });
            }
            db.SaveChanges();
        }



        /// <summary>
        /// Регистрация сведений о должностных обязанностях
        /// </summary>
        private static void InitPositionFunctions()
        {

            using (var db = new ManagmentDataModel())
            {
                InitPositionFunctions(db);
            }
        }

        private static void InitPositionFunctions(ManagmentDataModel db)
        {



            Writing.ToConsole("Регистрация сведений о должностных обязанностях ... ");
            var listOfPositions = db.Positions.ToList();
            foreach (var position in listOfPositions)
            {

                var function = new PositionFunction()
                {
                    Name = "Программирование",
                    Description = "Программирование",

                };
                position.PositionFunctions.Add(function);
                db.SaveChanges();
            }

            var skills = new HashSet<SKillExpirience>();
            while (skills.Count() < 3)
            {
                var skill = db.Skills.GetRandom<SKillExpirience>();
                skills.Add(skill);
            }
            foreach (var skill in skills)
            {
                var f = db.PositionFunctions.GetRandom<PositionFunction>();
                var functionSkill = new FunctionSkills()
                {
                    PositionFunction = f,
                    Skill = skill
                };
                f.FunctionSkills.Add(functionSkill);
                db.SaveChanges();
            }

        }








        private static void InitOrganizations()
        {
            using (var db = new ManagmentDataModel())
            {
                InitOrganizations(db);
            }
        }

        private static void InitOrganizations(ManagmentDataModel db)
        {
            bool valid = true;
            string inputSteps = "\n\nНеобходимо наполнить данными следующие таблицы: ";
            if (db.Organizations.Count() == 0)
            {
                ManagmentOrganization org = null;
                db.Organizations.Add(org=new ManagmentOrganization()
                {
                    INN = Randomizing.GetRandomSeries(10),
                    Name = "ООО Продукцив",
                    Description = "Поставщик товаров и услуг"
                });
                db.SaveChanges();
                db.Locations.Add(new ManagmentLocation()
                {
                    Organizations = new List<ManagmentOrganization>() { org },
                    Name = "Бизнес-центр Санкт-Петербург",
                    Description = "20 ИТ компаний"
                });
                db.SaveChanges();
            }
        }

        private static void EnsureIsValidate()
        {
            using (var db = new ManagmentDataModel())
            {
                bool valid = true;
                string inputSteps = "\n\nНеобходимо наполнить данными следующие таблицы: ";
                Action<string> ValidateDataExists = (tname) =>
                {
                    int count = ((IQueryable<BaseEntity>)db.GetDbSet(tname)).Count();
                    if (count == 0)
                    {
                        inputSteps += " " + (tname);
                        valid = false;
                    }
                };
                db.GetEntityTypeNames().ToList().ForEach(ValidateDataExists);
                if (!valid)
                {
                    throw new Exception(inputSteps);
                }
            }
        }

        private static void InitEmployessExpirience()
        {

            using (var db = new ManagmentDataModel())
            {
                InitEmployessExpirience(db);

            }

        }

        private static void InitEmployessExpirience(ManagmentDataModel db)
        {
            if (db.Employees.Count() == 0 || db.Skills.Count() == 0)
            {
                throw new Exception("Для регистрации опыта работников сначала нужно зарегистрировать самих работников и производственные навыки");
            }
            else
            {
                foreach (var e in db.Employees.Include(emp => emp.Expiriences).ToList())
                {
                    int n = 4;// Randomizing.GetRandomInt(3, 5);
                    for (int i = 0; i < n; i++)
                    {
                        if (e.Expiriences.Count() == 0)
                        {
                            db.EmployeeExpirience.Add(new EmployeeExpirience()
                            {
                                Created = DateTime.Now,
                                SkillID = db.Skills.GetRandom<SKillExpirience>().ID,
                                Begin = DateTime.Now.AddYears(-5).AddMonths(Randomizing.GetRandomInt(10, 20)),
                                EmployeeID = e.ID,
                                Granularity = 1
                            });

                            db.SaveChanges();
                        }

                    }
                    db.TimeSheets.Add(new TimeSheet()
                    {
                        BeginTime = DateTime.Now,
                        EmployeeID = db.Employees.GetRandom<Employee>().ID
                    });
                    db.SaveChanges();
                }




            }
        }
    }


    public class CandidateGenerator
    {
        public static string[] skills = new string[] {
        "ASP", "Java", "JS", "SQL", "PHP"
    };

        private static string MANS_NAMES_INPUT = "А АаронАбрамАвазАвгустинАвраамАгапАгапитАгатАгафонАдамАдрианАзаматАзатАзизАидАйдарАйратАкакийАкимАланАлександрАлексейАлиАликАлимАлиханАлишерАлмазАльбертАмирАмирамАмиранАнарАнастасийАнатолийАнварАнгелАндрейАнзорАнтонАнфимАрамАристархАркадийАрманАрменАрсенАрсенийАрсланАртёмАртемийАртурАрхипАскарАсланАсханАсхатАхметАшот Б БахрамБенджаминБлезБогданБорисБориславБрониславБулат В ВадимВалентинВалерийВальдемарВарданВасилийВениаминВикторВильгельмВитВиталийВладВладимирВладиславВладленВласВсеволодВячеслав Г ГавриилГамлетГарриГеннадийГенриГенрихГеоргийГерасимГерманГерманнГлебГордейГригорийГустав Д ДавидДавлатДамирДанаДаниилДанилДанисДаниславДаниэльДаниярДарийДауренДемидДемьянДенисДжамалДжанДжеймсДжереми ИеремияДжозефДжонатанДикДинДинарДиноДмитрийДобрыняДоминик Е ЕвгенийЕвдокимЕвсейЕвстахийЕгорЕлисейЕмельянЕремейЕфимЕфрем Ж ЖданЖерарЖигер З ЗакирЗаурЗахарЗенонЗигмундЗиновийЗурабЗуфар И ИбрагимИванИгнатИгнатийИгорьИероним ДжеромИисусИльгизИльнурИльшатИльяИльясИмранИннокентийИраклийИсаакИсаакийИсидорИскандерИсламИсмаилИтан К КазбекКамильКаренКаримКарлКимКирКириллКлаусКлимКонрадКонстантинКореКорнелийКристианКузьма Л ЛаврентийЛадоЛевЛенарЛеонЛеонардЛеонидЛеопольдЛоренсЛукаЛукиллианЛукьянЛюбомирЛюдвигЛюдовикЛюций М МаджидМайклМакарМакарийМаксимМаксимилианМаксудМансурМарМаратМаркМарсельМартин МартынМатвейМахмудМикаМикулаМилославМиронМирославМихаилМоисейМстиславМуратМуслимМухаммедМэтью Н НазарНаильНариманНатанНесторНикНикитаНикодимНиколаНиколайНильсНурлан О ОгюстОлегОливерОрестОрландоОсип ИосифОскарОсманОстапОстин П ПавелПанкратПатрикПедроПерриПётрПлатонПотапПрохор Р РавильРадийРадикРадомирРадославРазильРаильРаифРайанРаймондРамазанРамзесРамизРамильРамонРанельРасимРасулРатиборРатмирРаушанРафаэльРафикРашидРинат РенатРичардРобертРодимРодионРожденРоланРоманРостиславРубенРудольфРусланРустамРэй С СавваСавелийСаидСалаватСаматСамвелСамирСамуилСанжарСаниСаянСвятославСевастьянСемёнСерафимСергейСидорСимбаСоломонСпартакСтаниславСтепанСулейманСултанСурен Т ТагирТаирТайлерТалгатТамазТамерланТарасТахирТигранТимофейТимурТихонТомасТрофим У УинслоуУмарУстин Ф ФазильФаридФархадФёдорФедотФеликсФилиппФлорФомаФредФридрих Х ХабибХакимХаритонХасан Ц ЦезарьЦефасЦецилий СесилЦицерон Ч ЧарльзЧеславЧингиз Ш ШамильШарльШерлок Э ЭдгарЭдуардЭльдарЭмильЭминЭрикЭркюльЭрминЭрнестЭузебио Ю ЮлианЮлийЮнусЮрийЮстинианЮстус Я ЯковЯнЯромирЯрослав";
        private static string WOMANS_NAMES_INPUT = "А АваАвгустаАвгустинаАвдотьяАврораАгапияАгатаАгафьяАглаяАгнияАгундаАдаАделаидаАделинаАдельАдиляАдрианаАзаАзалияАзизаАидаАишаАйАйаруАйгеримАйгульАйлинАйнагульАйнурАйсельАйсунАйсылуАксиньяАланаАлевтинаАлександраАлексияАлёнаАлестаАлинаАлисаАлияАллаАлсуАлтынАльбаАльбинаАльфияАляАмалияАмальАминаАмираАнаитАнастасияАнгелинаАнжелаАнжеликаАнисьяАнитаАннаАнтонинаАнфисаАполлинарияАрабеллаАриаднаАрианаАриандаАринаАрияАсельАсияАстридАсяАфинаАэлитаАяАяна Б БаженаБеатрисБелаБелиндаБелла БэллаБертаБогданаБоженаБьянка В ВалентинаВалерияВандаВанессаВарвараВасилинаВасилисаВенераВераВероникаВестаВетаВикторинаВикторияВиленаВиолаВиолеттаВитаВиталина ВиталияВладаВладанаВладислава Г ГабриэллаГалинаГалияГаянаГаянэГенриеттаГлафираГоарГретаГульзираГульмираГульназГульнараГульшатГюзель Д ДалидаДамираДанаДаниэлаДанияДараДаринаДарьяДаянаДжамиляДженнаДженниферДжессикаДжиневраДианаДильназДильнараДиляДилярамДинаДинараДолоресДоминикаДомнаДомника Е ЕваЕвангелинаЕвгенияЕвдокияЕкатеринаЕленаЕлизаветаЕсенияЕя Ж ЖаклинЖаннаЖансаяЖасминЖозефинаЖоржина З ЗабаваЗаираЗалинаЗамираЗараЗаремаЗаринаЗемфираЗинаидаЗитаЗлатаЗлатославаЗорянаЗояЗульфияЗухра И Иветта ИветаИзабеллаИлинаИллирикаИлонаИльзираИлюзаИнгаИндираИнессаИннаИоаннаИраИрадаИраидаИринаИрмаИскраИя К КамилаКамиллаКараКареКаримаКаринаКаролинаКираКлавдияКлараКонстанцияКораКорнелияКристинаКсения Л ЛадаЛанаЛараЛарисаЛаураЛейлаЛеонаЛераЛесяЛетаЛианаЛидияЛизаЛикаЛилиЛилианаЛилитЛилияЛинаЛиндаЛиораЛираЛияЛолаЛолитаЛораЛуизаЛукерьяЛукияЛунаЛюбаваЛюбовьЛюдмилаЛюсильЛюсьенаЛюцияЛючеЛяйсанЛяля М МавилеМавлюдаМагдаМагдалeнаМадинаМадленМайяМакарияМаликаМараМаргаритаМарианнаМарикаМаринаМарияМариямМартаМарфаМеланияМелиссаМехриМикаМилаМиладаМиланаМиленМиленаМилицаМилославаМинаМираМирославаМирраМихримахМишельМияМоникаМуза Н НадеждаНаиляНаимаНанаНаомиНаргизаНатальяНеллиНеяНикаНикольНинаНинельНоминаНоннаНораНурия О ОдеттаОксанаОктябринаОлесяОливияОльгаОфелия П ПавлинаПамелаПатрицияПаулаПейтонПелагеяПеризатПлатонидаПолинаПрасковья Р РавшанаРадаРазинаРаиляРаисаРаифаРалинаРаминаРаянаРебеккаРегинаРезедаРенаРенатаРианаРианнаРикардаРиммаРинаРитаРогнедаРозаРоксанаРоксоланаРузалияРузаннаРусалинаРусланаРуфинаРуфь С СабинаСабринаСажидаСаидаСалимаСаломеяСальмаСамираСандраСанияСараСатиСаулеСафияСафураСаянаСветланаСевараСеленаСельмаСерафимаСильвияСимонаСнежанаСоняСофьяСтеллаСтефанияСусанна Т ТаисияТамараТамилаТараТатьянаТаяТаянаТеонаТерезаТеяТинаТиффаниТомирисТораТэмми У УльянаУмаУрсулаУстинья Ф ФазиляФаинаФаридаФаризаФатимаФедораФёклаФелиситиФелицияФерузаФизалияФирузаФлораФлорентинаФлоренция ФлоренсФлорианаФредерикаФрида Х ХадияХилариХлояХюррем Ц ЦаганаЦветанаЦецилия СесилияЦиара Сиара Ч ЧелсиЧеславаЧулпан Ш ШакираШарлоттаШахинаШейлаШеллиШерил Э ЭвелинаЭвитаЭлеонораЭлианаЭлизаЭлинаЭллаЭльвинаЭльвираЭльмираЭльнараЭляЭмилиЭмилияЭммаЭнжеЭрикаЭрминаЭсмеральдаЭсмираЭстерЭтельЭтери Ю ЮлианнаЮлияЮнаЮнияЮнона Я ЯдвигаЯнаЯнинаЯринаЯрославаЯсмина";
        private static string MANS_SECONDNAMES_INPUT = "АлексеевичАнатольевичАндреевичАнтоновичАркадьевичАртемовичБедросовичБогдановичБорисовичВалентиновичВалерьевичВасильевичВикторовичВитальевичВладимировичВладиславовичВольфовичВячеславовичГеннадиевичГеоргиевичГригорьевичДаниловичДенисовичДмитриевичЕвгеньевичЕгоровичЕфимовичИвановичИванычИгнатьевичИгоревичИльичИосифовичИсааковичКирилловичКонстантиновичЛеонидовичЛьвовичМаксимовичМатвеевичМихайловичНиколаевичОлеговичПавловичПалычПетровичПлатоновичРобертовичРомановичСанычСевериновичСеменовичСергеевичСтаниславовичСтепановичТарасовичТимофеевичФедоровичФеликсовичФилипповичЭдуардовичЮрьевичЯковлевичЯрославович";
        private static string MANS_SURNAMES_INPUT = "СмирновИвановКузнецовСоколовПоповЛебедевКозловНовиковМорозовПетровВолковСоловьёвВасильевЗайцевПавловСемёновГолубевВиноградовБогдановВоробьёвФёдоровМихайловБеляевТарасовБеловКомаровОрловКиселёвМакаровАндреевКовалёвИльинГусевТитовКузьминКудрявцевБарановКуликовАлексеевСтепановЯковлевСорокинСергеевРомановЗахаровБорисовКоролёвГерасимовПономарёвГригорьевЛазаревМедведевЕршовНикитинСоболевРябовПоляковЦветковДаниловЖуковФроловЖуравлёвНиколаевКрыловМаксимовСидоровОсиповБелоусовФедотовДорофеевЕгоровМатвеевБобровДмитриевКалининАнисимовПетуховАнтоновТимофеевНикифоровВеселовФилипповМарковБольшаковСухановМироновШиряевАлександровКоноваловШестаковКазаковЕфимовДенисовГромовФоминДавыдовМельниковЩербаковБлиновКолесниковКарповАфанасьевВласовМасловИсаковТихоновАксёновГавриловРодионовКотовГорбуновКудряшовБыковЗуевТретьяковСавельевПановРыбаковСуворовАбрамовВороновМухинАрхиповТрофимовМартыновЕмельяновГоршковЧерновОвчинниковСелезнёвПанфиловКопыловМихеевГалкинНазаровЛобановЛукинБеляковПотаповНекрасовХохловЖдановНаумовШиловВоронцовЕрмаковДроздовИгнатьевСавинЛогиновСафоновКапустинКирилловМоисеевЕлисеевКошелевКостинГорбачёвОреховЕфремовИсаевЕвдокимовКалашниковКабановНосковЮдинКулагинЛапинПрохоровНестеровХаритоновАгафоновМуравьёвЛарионовФедосеевЗиминПахомовШубинИгнатовФилатовКрюковРоговКулаковТерентьевМолчановВладимировАртемьевГурьевЗиновьевГришинКононовДементьевСитниковСимоновМишинФадеевКомиссаровМамонтовНосовГуляевШаровУстиновВишняковЕвсеевЛаврентьевБрагинКонстантиновКорниловАвдеевЗыковБирюковШараповНиконовЩукинДьячковОдинцовСазоновЯкушевКрасильниковГордеевСамойловКнязевБеспаловУваровШашковБобылёвДоронинБелозёровРожковСамсоновМясниковЛихачёвБуровСысоевФомичёвРусаковСтрелковГущинТетеринКолобовСубботинФокинБлохинСеливерстовПестовКондратьевСилинМеркушевЛыткинТуров";


        public static List<string> MANS_NAMES = GetManNames();
        public static List<string> MANS_SURNAMES = GetManSurnames();
        public static List<string> MANS_LASTNAMES = GetManLastnames();

        public static Employee GetEmployees()
        {
            int i1 = GetRandom(MANS_NAMES.Count() - 1);
            int i2 = GetRandom(MANS_SURNAMES.Count() - 1);
            int i3 = GetRandom(MANS_LASTNAMES.Count() - 1);
            if (i1 < 0 || i2 < 0 || i3 < 0)
            {
                throw new Exception("Индекс не может быть меньше нуля");
            }
            //Writing.ToConsole($"{i1},{i2},{i3}");
            string[] names = MANS_NAMES.ToArray();
            string name = names[i1];
            string[] surnames = MANS_SURNAMES.ToArray();
            string surname = surnames[i2];
            string[] lastnames = MANS_LASTNAMES.ToArray();
            string lastname = lastnames[i3];
            return new Employee()
            {
                FirstName = name,
                SurName = surname,
                LastName = lastname,
                Birthday = new DateTime(DateTime.Now.Year - GetRandom(50), GetRandom(12), GetRandom(28)),
                Tel = $"7-9{GetRandom(9)}{GetRandom(9)}-{GetRandom(9)}{GetRandom(9)}{GetRandom(9)}-{GetRandom(9)}{GetRandom(9)}{GetRandom(9)}{GetRandom(9)}",


            };
        }

        static int GetRandom(int max)
        {
            int res = new Random().Next(max);
            return res == 0 ? 1 : res;
        }

        public static List<string> GetManNames()
        {
            List<string> names = new List<string>();
            foreach (string text in MANS_NAMES_INPUT.Split(" "))
            {
                if (text.Length > 1)
                {
                    names.AddRange(new List<string>(Naming.SplitName(text)));
                }
            }
            return names;
        }
        public static List<string> GetManLastnames()
        {
            List<string> names = new List<string>();
            foreach (string text in MANS_SECONDNAMES_INPUT.Split(" "))
            {
                if (text.Length > 1)
                {
                    names.AddRange(new List<string>(Naming.SplitName(text)));
                }
            }
            return names;
        }
        public static List<string> GetManSurnames()
        {
            List<string> names = new List<string>();
            foreach (string text in MANS_SURNAMES_INPUT.Split(" "))
            {
                if (text.Length > 1)
                {
                    names.AddRange(new List<string>(Naming.SplitName(text)));
                }
            }
            return names;
        }
        public static List<string> GetWomanNames()
        {
            List<string> names = new List<string>();
            foreach (string text in WOMANS_NAMES_INPUT.Split(" "))
            {
                if (text.Length > 1)
                {
                    names.AddRange(new List<string>(Naming.SplitName(text)));
                }
            }
            return names;
        }
    }
}