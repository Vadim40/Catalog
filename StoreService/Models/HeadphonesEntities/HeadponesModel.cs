﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models.HeadphonesEntities
{
    public class HeadphonesModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }

}
