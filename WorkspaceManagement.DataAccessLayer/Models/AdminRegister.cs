﻿using System.ComponentModel.DataAnnotations;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class AdminRegister
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Password { get; set; }
    }
}
