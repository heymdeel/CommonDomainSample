using domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace custom4
{
    public class CustomRole : Role
    {
        public int CustomField { get; set; }

        public ICollection<CustomUser> CustomUsers { get; set; }
    }
}
