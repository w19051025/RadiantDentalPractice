﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadiantDentalPractice.models
{
    public class TreatmentPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int patientID { get; set; }
        public string proposedTreatment { get; set; }
        public string treatmentNotes { get; set; }
    }
}
