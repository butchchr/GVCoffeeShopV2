﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCCoffeeShopV2.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

    }
}