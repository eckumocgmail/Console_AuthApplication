using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

 
/// <summary>
/// Иерархическое преждставление набора данных
/// </summary>
/// <typeparam name="T"></typeparam>
public class HierTable<T>: DictionaryTable    where T : class
{

    [Label("Корневой каталог")]        
    [InputHidden(true)]
    [NotInput("")]
    public int? ParentID { get; set; }



    [InputHidden(true)]
    [NotInput("")]
    [JsonIgnore()]
    public virtual T Parent { get; set; }


   /* /// <summary>
    /// 
    /// </summary>    
    public override IEnumerable<ValidationResult> Validate(ValidationContext context)
    {   
        if(GetDbSet().Where(p => ((HierTable<T>)p).ParentID == null).Count() > 0)
        {
            if (this.ParentID == null)
                return new List<ValidationResult>() { 
                    new ValidationResult("Иерархический справочник должен иметь единтсвуенный узел не уимеющих указателя на предка, в данный момент такой узел уже существует") 
                };
        }
        return new List<ValidationResult>();
    }

        */



    /// <summary>
    /// Получение пути от истока
    /// </summary>        
    public virtual string GetPath(string separator)
    {
        HierTable<T> parentHier = ((HierTable<T>)((object)Parent));
        return (Parent != null) ? parentHier.GetPath(separator) + separator + Name : Name;
    }



    /// <summary>
    /// Получение всех узлов по пути к корню, начинаю с вызывающего узла.
    /// </summary>        
    public virtual List<HierTable<T>> GetRootNodes()
    {
        var res = new List<HierTable<T>>();
        res.Add(this);
        HierTable<T> parentHier = ((HierTable<T>)((object)Parent));
        while (parentHier != null)
        {
            res.Add(parentHier);
            parentHier.Join("Parent");
            parentHier = ((HierTable<T>)((object)parentHier.Parent));
        }
        return res;
    }


    /// <summary>
    /// Путь к узлу
    /// </summary>
    /// <returns></returns>
    public List<HierTable<T>> GetPath()
    {
        var path = new List<HierTable<T>>();
        path.Add(this);
        object p = Parent;            
        if(p != null)
        {            
            path.AddRange(((HierTable<T>)p).GetPath());
        }
        return path;
    }


    /// <summary>
    /// Исток
    /// </summary>
    /// <returns></returns>
    public BaseEntity GetRoot() {
        BaseEntity p =  this;
        while (p.GetProperty("ParentID") != null && p.GetProperty("ParentID") != p.GetProperty("ID"))
        {
            p.Join("Parent");
            p = (BaseEntity)p.GetProperty("Parent");
        }
        return p;
    }


    /// <summary>
    /// Потомки
    /// </summary>
    /// <returns></returns>
    public List<HierTable<T>> GetChildren() {
        var children = new List<HierTable<T>>();
        using(var db=new ApplicationData()){
            children = ((IQueryable<HierTable<T>>)(db.GetDbSet(typeof(T).Name))).Where(p => p.ParentID == ID).ToList();
        }
        return children;
    }


    /*
    /// <summary>
    /// Модель представления иерархии
    /// </summary>
    /// <returns></returns>
    public Tree ToTree() {
        var ChildNodes = new List<ViewNode>();
        GetChildren().ForEach(p => ChildNodes.Add(p.ToTree()));
        return new Tree() {
            Item=this,
            Children = ChildNodes
        };
    }*/



}
 