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
        
		// Key for schedule notification id
		public static string kToDoActivityKey = "ToDoIdActivityId";

		// Notification string constant
		public static string kShowAlertMessageKey = "ShowAlertMessage";
		public static string kOpenActivityDetailPageKey = "OpenActivityDetailPage";

        //Common string constants used in Droid and iOS
        public static string kViewTextKey = LocalizedResources.ViewTextKey;
        public static string kTitleTextKey = LocalizedResources.TitleTextKey;
        public static string kMessageTextKey = LocalizedResources.MessageTextKey;

        // Message constant
        public static string kLocationFetchFailedMessageKey = LocalizedResources.LocationFetchFailedMessageKey;
		public static string kErrorForGPSFailureKey = LocalizedResources.ErrorForGPSFailureKey;
		public static string kErrorForNetworkFailureKey = LocalizedResources.ErrorForNetworkFailureKey;
		public static string kLocationPermissionMessageKey = LocalizedResources.LocationPermissionMessageKey;
		public static string kGPSPermissionMessageKey = LocalizedResources.GPSPermissionMessageKey;
	}
}
