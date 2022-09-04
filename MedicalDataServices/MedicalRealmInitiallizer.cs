using Data;

using HospitalConstructor.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class MedicalRealmInitiallizer: IDisposable
{
    private MedicalDataModel db;
    public MedicalRealmInitiallizer(MedicalDataModel ctx) {
        db = ctx;
    }

    

    public void Dispose()
    {
        db.Dispose();
    }

    public void Info(object item)
    {
        Console.WriteLine($"[Info][{typeof(MedicalRealmInitiallizer).Name}]: {item}");
    }

    internal static void InitPrimaryData()
    {
        using (var p= new MedicalRealmInitiallizer(new MedicalDataModel()))
        {
            p.InitMedicalPositions();
            p.InitMedicalOrganiztions();
        }

        
    }

    public void InitMedicalPositions()
    {
        Info("Create Position");
        db.EmployeePositions.Add(new EmployeePosition()
        {
            Name = "Врач терапевт"
        });
        Info("Create Position");
        db.Add(new EmployeePosition()
        {
            Name = "Окулист"
        });
        Info("Create Position");

        db.Add(new EmployeePosition()
        {
            Name = "Невролог"
        });
        db.Add(new EmployeePosition()
        {
            Name = "Лор"
        });
        db.Add(new EmployeePosition()
        {
            Name = "Гастринтеролог"
        });
        db.Add(new EmployeePosition()
        {
            Name = "Гастринтеролог"
        });
        db.Add(new EmployeePosition()
        {
            Name = "Хирург"
        });
        db.SaveChanges();
    }




    private void InitMedicalOrganiztions()
    { 
        if (db.MedOrganizations.Count() == 0)
        {
            for (int i = 0; i < 255; i++)
            {
                ManagmentOrganization mo = null;
                db.Add(mo = new ManagmentOrganization()
                {
                    Name = "Городская поликлиника №" + i
                });
                db.SaveChanges();

                mo.ManagmentDepartments = new List<OrganizationDepartment>();
                mo.ManagmentDepartments.Add(CreateMedicalReceptionDepartment());
                mo.ManagmentDepartments.Add(CreateStatisticsDepartment());
                mo.ManagmentDepartments.Add(CreateFinancialDepartment());
                mo.ManagmentDepartments.Add(new OrganizationDepartment()
                {
                    Name = "Хозяйственный отдел"
                });
                mo.ManagmentDepartments.Add(HumanResourceDepartment());
                mo.ManagmentDepartments.Add(CreateAdministraqtiveDepartment());
                mo.ManagmentDepartments.Add(CreateMedicalTerapyDepartment());
                mo.ManagmentDepartments.Add(CreateDiagnosticsDepartment());
                mo.ManagmentDepartments.Add(CreateLabDeaprtment());

            }
        }
        db.SaveChanges();



            
    }

    private OrganizationDepartment CreateLabDeaprtment()
    {
        var dep = new MedicalDepartment()
        {
            Name = "Биохимичская лаборатория",
            MedicalType = "LabDepartment"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

 

    private OrganizationDepartment CreateDiagnosticsDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Процедурный кабинет"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private OrganizationDepartment CreateMedicalTerapyDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Терапевтическое отделение"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private OrganizationDepartment CreateAdministraqtiveDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Администрация"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Employee GetManagmentEmployees()
    {
        using (var db=new ManagmentDataModel())
        {
   
            var n=db.Employees.Count();
            return db.Employees.ToArray()[new Random().Next(1,n)-1];
        }
    }

    private OrganizationDepartment HumanResourceDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Отдел кадров"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private OrganizationDepartment CreateFinancialDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Бухгалтерия"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private OrganizationDepartment CreateStatisticsDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Статистика"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private OrganizationDepartment CreateMedicalReceptionDepartment()
    {
        var dep = new OrganizationDepartment()
        {
            Name = "Регистратура"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }
}

