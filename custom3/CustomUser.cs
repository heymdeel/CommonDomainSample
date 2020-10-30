using domain;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace custom3
{
    public class CustomUser : User
    {
        public string Region { get; set; }

        public new CustomRole Role { get; set; }
    }
}
