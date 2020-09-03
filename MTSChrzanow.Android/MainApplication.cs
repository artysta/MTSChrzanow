using Android.App;
using Android.Runtime;
using Shiny;
using Shiny.Notifications;
using System;

namespace MTSChrzanow.Droid
{
	[Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //AndroidOptions.DefaultSmallIconResourceName = "icon";
            AndroidOptions.DefaultLaunchActivityFlags = AndroidActivityFlags.FromBackground;
            AndroidOptions.DefaultNotificationImportance = AndroidNotificationImportance.High;
            //AndroidOptions.AutoCancel = false;
            AndroidShinyHost.Init(this, platformBuild: services => services.UseNotifications());
        }
    }
}