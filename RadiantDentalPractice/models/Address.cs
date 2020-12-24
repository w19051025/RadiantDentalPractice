﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantDentalPractice.models
{
    /*
    * @author venkata sravan kumar
    * 
    */
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }

    }
}
