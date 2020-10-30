using domain;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace custom4
{
    public class CustomUser : User
    {
        public string Region { get; set; }

        public CustomRole CustomRole { get; set; }
    }
}
