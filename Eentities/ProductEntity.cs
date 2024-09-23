using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eentities
{
    public class ProductEntity
    {
        [Key]
        [StringLength(30)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(600)]
        public string ProductDescription { get; set; }

        public int TotalQuantity { get; set; }

        public string CategoryId { get; set; }

        public CategoryEntity? Category { get; set; }

        public ICollection<StorageEntity> Storages { get; set; }

        public ProductEntity()
        {
            ProductId = "default";
            ProductName = "default";
            ProductDescription = "default";
            CategoryId = "default";

            Storages = new List<StorageEntity>();
        }




    }
}
