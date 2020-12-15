﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IPatientRepository getPatientRepository()
        {
            return new PatientRepository();
        }
    }
}