﻿using System.ComponentModel.DataAnnotations;

namespace KeyBox.Core.Dto.Student
{
    public class StudentDTO
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }  // Only "SENIOR" or "JUNIOR"
    }

}
