using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ResourcesDataInitiallzer
{
    private static void InitCatalog(ResourcesService service)
    {
        var catalog = new TypeCatalog(@"D:\System-Config\FileStore", "FileStore");
        service.Import(catalog);
        service.Export("FileStore", @"D:\System-Config\FileStoreExt");
    }
    public static void InitPrimaryData()
    {
        using (var db = new ResourcesDataModel())
        {
            var service = new ResourcesService(db);
            InitCatalog(service);
        }
    }
}