using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace ToDoActivity
{
    public partial class CreateActivityPage : ContentPage
    {
        CreateActivityViewModel viewModel;
        public CreateActivityPage(ActivityModel activityModel)
        {
            InitializeComponent();
            viewModel = new CreateActivityViewModel(Navigation, activityModel);
            BindingContext = viewModel;

            if (activityModel != null)
            {
                Title = "Edit";
                deleteButton.IsVisible = true;
            }
            else
            {
                deleteButton.IsVisible = false;
            }

            var Date = DateTime.Now;
            datePicker.MinimumDate = Date;
            timePicker.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
        }

        // Date Selection
        void HandleDateSelected(object sender, DateChangedEventArgs e)
        {
            DateUpdate();
        }

        // Time Selection
        void HandleTimeChanged(object sender, PropertyChangedEventArgs e)
        {
            DateUpdate();
        }

        // Private Method
        private void DateUpdate()
        {
            var Date = DateTime.Now;

            int year = Date.Year;
            int month = Date.Month;
            int day = Date.Day;
            int hour = Date.Hour;
            int minute = Date.Minute;

            if (datePicker != null)
            {
                year = datePicker.Date.Year;
                month = datePicker.Date.Month;
                day = datePicker.Date.Day;
            }

            if (timePicker != null)
            {
                hour = timePicker.Time.Hours;
                minute = timePicker.Time.Minutes;

                //Set the error if invalid time is selected
                if (DateTime.Now.Day == datePicker.Date.Day & DateTime.Now.Month == datePicker.Date.Month & DateTime.Now.Year == datePicker.Date.Year)
                    SetTimeError(hour, minute);
                else
                    errorTimeLabel.Text = "";
            }

            // Date update 
            if (viewModel != null)
            {
                viewModel.SelectedDate = new DateTime(year, month, day, hour, minute, 0);
            }
        }

        // To set the error if invalid time is selected
        private void SetTimeError(int hour, int minute)
        {
            if (errorTimeLabel != null) { 
                if (DateTime.Now.Hour > hour)
                {
                    errorTimeLabel.Text = "Please select future time!";
                }
                else
                {
                    errorTimeLabel.Text = "";
                }
            }
        }
    }
}
