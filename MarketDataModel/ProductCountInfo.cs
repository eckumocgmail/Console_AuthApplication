

using System.ComponentModel;

namespace MvcMarketPlace.Data.Entities
{

    /// <summary>
    /// сведения о объеме продукции на точке сбыта
    /// </summary>
    public class ProductCountInfo : DictionaryTable 
    {
      
        

        [DisplayName("Продукт")]
        public int ProductID { get; set; }
        public ProductDescription Product { get; set; }


        [DisplayName("Склад")]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }


        [DisplayName("Кол-во")]
        public int Count { get; set; }
    }
}