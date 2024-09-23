using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Eentities
{
    public class WhereHouseEntity
    {
        [Key]
        [StringLength(50)]
        public string WhereHouseId { get; set; } 

        [Required]
        [StringLength(100)]
        public string WhereHouseName { get; set; } 

        [Required]
        [StringLength(100)]
        public string WhereHouseAddress { get; set; }
        public ICollection<StorageEntity> Storages { get; set; }

        public WhereHouseEntity()
        {
            WhereHouseId = "default";
            WhereHouseName = "default";
            WhereHouseAddress = "default";
            Storages = new List<StorageEntity>();
        }

    }

}
