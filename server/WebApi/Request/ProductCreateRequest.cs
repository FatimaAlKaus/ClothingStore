﻿namespace WebApi.Request
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(100, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(1)]
        public int[] Categories { get; set; }
    }
}
