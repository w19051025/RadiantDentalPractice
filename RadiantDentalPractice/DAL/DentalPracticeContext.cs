﻿using RadiantDentalPractice.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.DAL
{
    class DentalPracticeContext : DbContext
    {
        public DentalPracticeContext(): base("DentalPracticeContext")
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<GP> GP_details { get; set; }
        public DbSet<Address> address_details { get; set; }
    }
}
