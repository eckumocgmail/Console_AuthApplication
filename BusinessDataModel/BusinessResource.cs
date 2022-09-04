

using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;



[Label("Ресурсы предприятия")]
[SearchTerms("Name")]
public class BusinessResource : ActiveObject
{




    [Label("Корневой каталог")]
    [SelectDictionary("GetType().Name,Name")]
    public int? ParentID { get; set; }


    [InputHidden(true)]
    public virtual BusinessResource Parent { get; set; }

   

    [NotNullNotEmpty()]
    [UniqValidation( )]
    public string Code { get; set; }


    /*
    public string GetPath(string separator)
    {
        BusinessResource parentHier =  Parent ;
        return (Parent != null) ? parentHier.GetPath(separator) + separator + Name : Name;
    }

    public override Tree ToTree()
    {
        throw new System.NotImplementedException();
    }*/
}
