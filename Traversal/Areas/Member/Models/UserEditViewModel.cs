﻿namespace Traversal.Areas.Member.Models
{
    public class UserEditViewModel
    {
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; } 
    }
}
