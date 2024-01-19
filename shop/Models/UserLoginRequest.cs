﻿using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class UserLoginRequest
    {
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
