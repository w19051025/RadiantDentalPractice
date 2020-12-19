﻿using RadiantDentalPractice.Helper;
using RadiantDentalPractice.presenter;
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
    public partial class EmergencyForm : Form,IEmergencyView
    {
        public EmergencyForm()
        {
            InitializeComponent();
        }

        public int patientID
        {
            get
            {
                return int.Parse(patientIDTXT.Text);
            }
            set
            {
                patientIDTXT.Text = value.ToString();
            }
        }
        public DateTime bookingDate
        {
            get
            {
                return bookingDateTXT.Value.Date;
            }
            set
            {
                bookingDateTXT.Value = value;
            }
        }

        public String bookingSlot
        {
            get
            {
                return bookingSlotTXT.Text;
            }
            set
            {
                bookingSlotTXT.Text = value;
            }
        }
        public EmergencyPresenter emergencyPresenter { get; set; }

        private void Book_Click(object sender, EventArgs e)
        {
            try
            {
                int result = emergencyPresenter.CreateEmergencyBooking();
                if (result > 0)
                {
                    MessageBox.Show("Emergency Appointment Booked");
                }
                else
                {
                    MessageBox.Show("Emergency Appointment Not Successful");
                }
            }
            catch
            {
                MessageBox.Show("Error Occured during Emergency Appointment");
            }
            this.Close();
        }

        private void bookingDateTXT_ValueChanged(object sender, EventArgs e)
        {
            bookingSlotTXT.Items.Clear();
            bookingSlotTXT.Text = "";
            List<string> bookingSlots = AppointmentHelper.getEmergencySlots(bookingDateTXT.Value);
            List<string> bookedSlots = new List<string>();
            if (bookingSlots.Count != 0)
            {
                bookedSlots = AppointmentHelper.
                bookedCheckupSlots(new DateTime(bookingDate.Year, bookingDate.Month, bookingDate.Day));
            }

            List<string> availableSlots = bookingSlots.Except(bookedSlots).ToList();


            bookingSlotTXT.Items.AddRange(availableSlots.ToArray());
        }
    }
}