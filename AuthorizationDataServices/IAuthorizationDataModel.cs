using ApplicationCore.Converter;

using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAuthorizationDataModel: IDbContext
{
 
    public DbSet<UserAccount> Accounts { get; set; }
    public DbSet<UserGroup> Groups { get; set; }
    public DbSet<GroupMessage> GroupMessages { get; set; }
    public DbSet<LoginEvents> LoginEvents { get; set; }
    public DbSet<UserMessage> Messages { get; set; }
    public DbSet<ServiceMessage> News { get; set; }    
    public DbSet<UserPerson> Persons { get; set; }
    public DbSet<UserSettings> Settings { get; set; }
    public DbSet<UserContext > Users { get; set; }
    public DbSet<UserGroups> UserGroups { get; set; }        
}