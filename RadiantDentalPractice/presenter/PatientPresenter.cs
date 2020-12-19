﻿using RadiantDentalPractice.Factory;
using RadiantDentalPractice.models;
using RadiantDentalPractice.Repository;
using RadiantDentalPractice.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiantDentalPractice.presenter
{
    public class PatientPresenter
    {

        
        private Patient patient;
        private IViewFactory viewFactory;
        private IPresenterFactory presenterFactory;
        private IRepositoryFactory repositoryFactory;


        public PatientPresenter(IViewFactory viewFactory,
            IPresenterFactory presenterFactory, IRepositoryFactory repositoryFactory)
        {
            this.viewFactory = viewFactory;
            this.presenterFactory = presenterFactory;
            this.repositoryFactory = repositoryFactory;
        }

        public IPatientView view { get; set; }

        public void RegisterPatient(IQuestionView questionView)
        {
            initializePatient();
            QuestionnairePresenter questionnairePresenter = presenterFactory.getQuestionnairePresenter( 
                patient, presenterFactory, repositoryFactory);
            questionnairePresenter.view = questionView;
            questionView.questionnairePresenter = questionnairePresenter;
        }

        public void validate()
        {
            validationChecks();
        }

        private Boolean isEmailRegistered(string email)
        {
            int result = repositoryFactory.getPatientRepository().isEmailRegistered(email);
            if(result>0)
            {
                return true;
            }
            return false;
        }
        private Boolean verifyEmail()
        {
            try
            {
                MailAddress mailAddress = new MailAddress(view.email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void validationChecks()
        {
            if(view.name.Trim().Length==0)
            {
                view.errorMessage = "Please enter name";
            }
            else if (view.email.Trim().Length == 0)
            {
                view.errorMessage = "Please enter email";
            }
            else if (!verifyEmail())
            {
                view.errorMessage = "Please enter valid email address";
            }
            else if (isEmailRegistered(view.email))
            {
                view.errorMessage = "Email is already registered";
            }
            else if (view.city.Trim().Length == 0)
            {
                view.errorMessage = "Please enter city";
            }
            else if (view.country.Trim().Length == 0)
            {
                view.errorMessage = "Please enter country";
            }
            else if (view.postcode.Trim().Length == 0)
            {
                view.errorMessage = "Please enter postcode";
            }
            else if (view.dob > DateTime.Now)
            {
                view.errorMessage = "Please enter valid date of birth";
            }
        }

        private void initializePatient()
        {
            patient = new Patient();
            patient.address = new Address();
            patient.gp_details = new GP();
            patient.medicalQuestions = new MedicalQuestions();
            patient.medicalQuestions.questions = new HashSet<Question>();
            patient.name = view.name;
            patient.email = view.email;
            patient.dob = view.dob;
            patient.address.city = view.city;
            patient.address.postcode = view.postcode;
            patient.address.country = view.country;
        }
    }
}
