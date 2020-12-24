﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.Repository
{
    /*
     * @author venkata sravan kumar
     * 
     * interface for factory class
     */
    public interface IRepositoryFactory
    {
        IPatientRepository getPatientRepository();
        //IAppointmentRepository getAppointmentRepository();
        IAppointmentRepository getAppointmentRepository();
        ITreatmentPlanRepository getTreatmentPlanRepository();
        IStaffRepository getStaffRepository();
    }
}
