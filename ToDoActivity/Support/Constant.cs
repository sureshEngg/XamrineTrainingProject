using System;
using ToDoActivity.Support;

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
		public static string kViewTextKey = AppResources.kViewTextKey;
		public static string kTitleTextKey = AppResources.kTitleTextKey;
		public static string kMessageTextKey = AppResources.kMessageTextKey;

		// Key for schedule notification id
		public static string kToDoActivityKey = "ToDoIdActivityId";

		// Notification string constant
		public static string kShowAlertMessageKey = "ShowAlertMessage";
		public static string kOpenActivityDetailPageKey = "OpenActivityDetailPage";

		// Message constant
		public static string kLocationFetchFailedMessageKey = AppResources.kLocationFetchFailedMessageKey;
		public static string kSelectTimeAlertKey = AppResources.kSelectTimeAlertKey;
        public static string kErrorForGPSFailureKey = AppResources.kErrorForGPSFailureKey;
		public static string kErrorForNetworkFailureKey = AppResources.kErrorForNetworkFailureKey;
		public static string kLocationPermissionMessageKey = AppResources.kLocationPermissionMessageKey;
		public static string kGPSPermissionMessageKey = AppResources.kGPSPermissionMessageKey;
	}
}
