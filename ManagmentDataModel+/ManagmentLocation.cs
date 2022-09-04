

using Newtonsoft.Json;

using System.Collections.Generic;

[Label("Локация")]
public class ManagmentLocation : DictionaryTable
{
    [JsonIgnore]
    public ICollection<ManagmentOrganization> Organizations { get; set; }
}