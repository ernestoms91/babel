﻿using System.ComponentModel.DataAnnotations;

namespace Babel.Models.Dtos
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, ErrorMessage = "Lastname can't be longer than 50 characters")]
        public string Lastname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "NID is required")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "NID must be exactly 11 digits")]
        public string Nid { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;

        [MinLength(1, ErrorMessage = "At least one role must be provided")]
        public int[] Roles { get; set; } = Array.Empty<int>();

    }
}
