 
using ApplicationDb.Entities;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public interface APIAuthorization:  APIRegistration
{
    bool IsSignin();
    bool InBusinessResource(string roleName);
    bool IsActivated();
    UserContext  Signin(string RFIDLabel);
    UserContext  Signin(string Email, string Password, bool? IsFront=false);
    void Signout(bool? IsFront = false);
    UserContext  Verify(bool? IsFront = false);               
    ConcurrentDictionary<string, object> Session();
    Task<UserAccount> GetAccountByID(int iD);
}
