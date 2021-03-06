﻿using RadiantDentalPractice.models;
using RadiantDentalPractice.Repository;
using RadiantDentalPractice.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * GPPresenter responsible to update the GP details to the patient model.
 * It will call Patient Repository to insert the data to database
 */

namespace RadiantDentalPractice.presenter
{
    /*
    * @author venkata sravan kumar
    * 
    */
    public class GPPresenter
    {

        
        Patient patient;
        IRepositoryFactory repositoryFactory;
        IPresenterFactory presenterFactory;

        public GPPresenter(Patient patient, IRepositoryFactory repositoryFactory, IPresenterFactory presenterFactory)
        {
            this.patient = patient;
            this.repositoryFactory = repositoryFactory;
            this.presenterFactory = presenterFactory;
        }

        public IGpView view { get; set; }

        public int updatePatient()
        {
            updateAddress();
            IPatientRepository patientRepository = ((IPatientRepository)repositoryFactory.getRepository("PATIENT"));
            return patientRepository.addPatient(patient);
        }

        public void registerCheckupPresenter(ICheckupView checkupView)
        {
            CheckUpPresenter checkUpPresenter = presenterFactory.getCheckUpPresenter(checkupView,
                (IAppointmentRepository)repositoryFactory.getRepository("APPOINTMENT"));
            checkupView.checkUpPresenter = checkUpPresenter;
        }

        private void updateAddress()
        {
            patient.gp_details.name = view.name;
            patient.gp_details.address = view.address;
        }



        public void validate()
        {
            validationChecks();
        }
        private void validationChecks()
        {
            if (view.name.Trim().Length == 0)
            {
                view.errorMessage = "Please enter GP name";
            }
            else if (view.address.Trim().Length == 0)
            {
                view.errorMessage = "Please enter GP address";
            }

        }
    }
}
