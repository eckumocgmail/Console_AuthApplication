using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

 
/// <summary>
/// Абстрактный класс активных обьектов приложения( пользователи, службы ).
/// Активные обьекты проходят процедуру авторизации в приложении.
/// </summary>
public abstract class ActiveObject: DictionaryTable
{
        
  
    [Label("Последнее посещение")]
    public DateTime LastActiveTime { get; set; } = DateTime.Now;
        


    [Label("Онлайн")]
    public bool IsActive { get; set; }


    [Label("Секретный ключ")]
    public string SecretKey { get; set; }


    //время в мс
    public long GetTimeStamp()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }


    //дата-время в формате дд.мм.гггг чч.мм.сс
    public string GetLastActiveTime()
    {
        var ptime = LastActiveTime;
        return $"" +
            $"{ptime.Hour}:{ptime.Minute}.{ptime.Second}";
    }

}

