﻿using RadiantDentalPractice.presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.views
{
    /*
     * @author venkata sravan kumar
     * 
     * interface for AddStaffForm
     * 
     */
    public interface IAddStaffView
    {
        string name { get; set; }
        string role { get; set; }
        AddStaffPresenter addStaffPresenter { get; set; }
        string errorMessage { get; set; }
    }
}
