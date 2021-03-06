﻿using RadiantDentalPractice.presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiantDentalPractice.views
{
    /*
     * @author venkata sravan kumar
     * 
     * this form allows us to take consent from patient
     */
    public partial class TreatmentConsentAndPaymentForm : Form, ITreatmentConsentView
    {
        public TreatmentConsentAndPaymentForm()
        {
            InitializeComponent();
        }

        public double treatmentCost
        {
            get
            {
                return double.Parse(PaymentTXT.Text);
            }
            
            set
            {
                PaymentTXT.Text = value.ToString();
            }
        }
        public string consentText
        {
            get
            {
                return Consent.Text;
            }
            set
            {
                Consent.Text = value;
            }
        }
        public Boolean isAccepted
        {
            get
            {
                return consentTXT.Checked;
            }
            set
            {
                consentTXT.Checked = value;
            }
        }

        public TreatmentConsentPresenter treatmentConsentPresenter { get; set; }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (isAccepted)
            {
                int result = treatmentConsentPresenter.updateTreatmentPlan();
                if (result > 0)
                {
                    MessageBox.Show("Success");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("You must Accept the terms and conditions");
                DialogResult dialogResult = MessageBox.Show("Do You want to Continue?",
                    "Treatment Plan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
                       
        }
    }
}
