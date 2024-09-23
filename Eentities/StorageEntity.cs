using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eentities
{
    public class StorageEntity
    {
        [Key]
        [StringLength(50)]
        public string StorageId { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int PartialQuantity { get; set; }

        public string ProductId { get; set; }

        public ProductEntity Product { get; set; } 

        public string WhereHouseId { get; set; } 

        public WhereHouseEntity WhereHouse { get; set; } 

        public ICollection<InputOutputEntity> InputOutputs { get; set; }


        //public StorageEntity()
        //{
        //    StorageId = "default";
        //    LastUpdate = DateTime.UtcNow;
        //    PartialQuantity = 0;
        //    ProductId = "default";
        //    WhereHouseId = "default";
        //    Product = new ProductEntity();
        //    WhereHouse = new WhereHouseEntity();
        //    InputOutputs = new List<InputOutputEntity>();

        //}

    }

}

  
