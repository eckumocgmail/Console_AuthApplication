using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Api.Utils;

public class AuthApplicationProgram
{
    public static void Start(ref string[] args)
    {
        Clear();
        switch (ProgramDialog.SingleSelect("Выберите действие", new string[]{
            "Авторизация",
            "Регистрация",
            "Выход" }, ref args))
        {
            case "Авторизация":
                Authorization(ref args); break;
            case "Регистрация":
                Registration(ref args); break;           
            case "Выход":
                Exit();
                break;
            default: break;
        }
    }

    private static void Authorization(ref string[] args)
    {
        throw new NotImplementedException();
    }

    private static void Registration(ref string[] args)
    {
        throw new NotImplementedException();
    }
}

