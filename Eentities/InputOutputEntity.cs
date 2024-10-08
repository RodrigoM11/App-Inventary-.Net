﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Eentities
{
    public class InputOutputEntity
    {

        [Key]
        [StringLength(50)]
        public string InOutId { get; set; }

        [Required]
        public DateTime InOutDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsInput { get; set; }

        public string StorageId { get; set; }
        public StorageEntity Storage { get; set; }


        //public InputOutputEntity()
        //{
        //    InOutId = "default";
        //    InOutDate = DateTime.UtcNow;
        //    Quantity = 0;
        //    IsInput = true;
        //    StorageId = "default";
        //    Storage = new StorageEntity();

        //}

    }

}
