﻿using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
