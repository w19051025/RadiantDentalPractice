﻿using RadiantDentalPractice.models;
using RadiantDentalPractice.Repository;
using RadiantDentalPractice.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.presenter
{
    /*
    * @author venkata sravan kumar
    * 
    */
    public class SetAvailabilityPresenter
    {
        private IStaffRepository staffRepository;
        public SetAvailabilityPresenter(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public ISetAvailabilityView view { get; set; }

        public Boolean setAvailability()
        {
            int staff_id =  staffRepository.getStaffIDByName(view.name);
            StaffAvailability staffAvailability = new StaffAvailability();
            staffAvailability.staff_id = staff_id;
            staffAvailability.availabilityStatus = view.availabilityStatus;
            staffAvailability.date = view.selectedDate;
            if(staff_id!=0)
            {
                return staffRepository.updateAvailability(staffAvailability);
            }
            else
            {
                return false;
            }
        }

        public List<Staff> loadStaffDetails()
        {
            return staffRepository.retrieveStaff();
        }

        public void validate()
        {
            validationChecks();
        }
        private void validationChecks()
        {
            if (view.name.Trim().Length == 0)
            {
                view.errorMessage = "Please select name";
            }
            else if (view.selectedDate.CompareTo(DateTime.Now) <= 0)
            {
                view.errorMessage = "Please select future date";
            }
            else if (view.availabilityStatus.Trim().Length == 0)
            {
                view.errorMessage = "Please select Availability Status";
            }

        }
    }
}
