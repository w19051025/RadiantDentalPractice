﻿using RadiantDentalPractice.presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.views
{
    public interface IDentalSurgeryVisitView
    {
        int PatientID { get; set; }
        DentalSurgeryVisitPresenter dentalSurgeryVisitPresenter { get; set; }
    }
}
