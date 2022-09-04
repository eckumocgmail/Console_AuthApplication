using ApplicationDb.Entities;



/// <summary>
/// Сервис управления службами веб-API
/// </summary>
public interface APIWebServices : APIActiveCollection<UserContext >
{

    /// <summary>
    /// Регистрация сервиса в каталоге, возвращает последовательность.
    /// </summary>
    public byte[] PublishWebService( );


    
}
