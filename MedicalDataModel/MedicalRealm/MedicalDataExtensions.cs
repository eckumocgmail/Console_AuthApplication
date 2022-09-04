//using BlazorHospital.Shared.SharedData.DataModels.MediсalDataModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
 
using System;
using ApplicationDb.Entities;

public static class MedicalDataExtensions 
{

    /// <summary>
    /// Регистрация источника данных медицинской информации ADO.NET SQL-Server
    /// </summary>
    public static IServiceCollection AddMedicalSqlServerDataContext(this IServiceCollection services, string Server) 
    {
        Console.WriteLine($"[Info][{typeof(MedicalDataModel).Name}]: AddMedicalSqlServerDataContext({Server})");
        //services.AddSqlServer<ApplicationDbContext>(Server,true);
        //services.AddTransient<IMedicalDataContext, MedicalSqlServerContext>();
        return services;
    }


    public static IServiceCollection AddMedicalEntitiesFasade(this IServiceCollection services)
    {
         
        return services;
    }
}
