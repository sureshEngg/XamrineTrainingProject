using System;
namespace ToDoActivity
{
	public static class Constant
	{


		// Value constant
		public static int kDesiredLocationAccuracyValue = 500000;

		// Database name constant
		public static string kDatabaseTextKey = "Databases";
		public static string kLibraryTextKey = "Library";
		public static string kDatabaseNameKey = "TodoSQLite.db3";
		public static string kTwoDotsTextKey = "..";


		// Common string constant
		public static string kOkTextKey = "OK";
		public static string kEditTextKey = "Edit";
		public static string kNewTextKey = "New";
		public static string kSaveTextKey = "Save";
		public static string kBackTextKey = "Back";
		public static string kViewTextKey = "View";
		public static string kTitleTextKey = "Title";
		public static string kMessageTextKey = "Message";

		// Key for schedule notification id
		public static string kToDoActivityKey = "ToDoIdActivityId";

		// Notification string constant
		public static string kShowAlertMessageKey = "ShowAlertMessage";
		public static string kOpenActivityDetailPageKey = "OpenActivityDetailPage";

		// Message constant
		public static string kLocationFetchFailedMessageKey = "Unable to get location: ";
		public static string kSelectTimeAlertKey = "Please select future time!";
		public static string kErrorForGPSFailureKey = "Error in GPS = ";
		public static string kErrorForNetworkFailureKey = "Error in Network = ";
		public static string kLocationPermissionMessageKey = "Location access is required to read current location.";
		public static string kGPSPermissionMessageKey = "GPS will not be available for Application due denial of GPS permission!";
	}
}
