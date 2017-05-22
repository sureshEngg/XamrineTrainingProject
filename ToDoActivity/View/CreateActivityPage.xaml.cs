using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToDoActivity.Support;
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
				Title = LocalizedResources.EditTextKey;
				deleteButton.IsVisible = true;

				datePicker.MinimumDate = activityModel.DueDate;
				timePicker.Time = new TimeSpan(activityModel.DueDate.Hour, activityModel.DueDate.Minute, 0);
			}
			else
			{
				deleteButton.IsVisible = false;
				LoadRecentEntry();

				var Date = DateTime.Now;
				datePicker.MinimumDate = Date;
				timePicker.Time = new TimeSpan(Date.Hour, Date.Minute, 0);
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			viewModel.SaveRecentEntries();
		}

		private async void LoadRecentEntry()
		{
			var entryModel = await RecentEntryModel.GetItemAsync();

			if (entryModel != null)
			{
				nameEntry.Text = entryModel.Name;
				descriptionEntry.Text = entryModel.Description;
			}
			else
			{
				nameEntry.Text = string.Empty;
				descriptionEntry.Text = string.Empty;
			}
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
			}

			// Date update 
			if (viewModel != null)
			{
				viewModel.SelectedDate = new DateTime(year, month, day, hour, minute, 0);
			}

			//Validate Selected Date
			ValidateSelectedDate();
		}


		private void ValidateSelectedDate()
		{
			if (timePicker != null && datePicker != null)
			{
				int result = DateTime.Compare(DateTime.Now, viewModel.SelectedDate);

				if (result >= 0)
				{
					viewModel.isDateValid = false;
					errorTimeLabel.Text = LocalizedResources.SelectTimeAlertKey;
				}
				else
				{
					viewModel.isDateValid = true;
					errorTimeLabel.Text = string.Empty;
				}
			}
		}
	}
}
