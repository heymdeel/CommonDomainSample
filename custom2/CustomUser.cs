using domain;
using System;
using System.Collections;

namespace custom2
{
    public class CustomUser : User
    {
        public string Region { get; set; }

        public new CustomRole Role { get; set; }
    }
}
