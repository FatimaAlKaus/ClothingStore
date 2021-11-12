﻿namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; init; }

        [Required]
        [Range(20, int.MaxValue)]
        public int Price { get; init; }

        [Required]
        [MinLength(1)]
        public int[] Categories { get; init; }
    }
}
