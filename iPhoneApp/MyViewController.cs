using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace iOS.WebServiceExample.iPhoneApp
{
    public class MyViewController : UIViewController
    {
        UIButton buttonGetCerts, buttonClasses, buttonUploadNewClass;
        float buttonWidth = 200;
        float buttonHeight = 50;
        string url = "http://192.168.5.201"; // Make sure to add your own IP so that your iOS device can reach the Web API.

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            #region Certificates button

            // Setup button UI
            buttonGetCerts = UIButton.FromType(UIButtonType.RoundedRect);
            buttonGetCerts.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                200,
                buttonWidth,
                buttonHeight);
            buttonGetCerts.SetTitle("Get certificates", UIControlState.Normal);

            // Handle button touch
            buttonGetCerts.TouchUpInside += async (object sender, EventArgs e) =>
            {
                // Call API and get certificates from web api
                var certs = await new Api(url).GetCertificatesAsync();

                // Process certificates & display alert
                if (certs != null)
                {
                    string message = "";

                    foreach (var cert in certs)
                        message += cert.Name + ";\r";

                    Alert("Xamarin Certificates", message);
                }
            };
            buttonGetCerts.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin;
            View.AddSubview(buttonGetCerts);
            #endregion

            #region Class button

            // Setup button UI
            buttonClasses = UIButton.FromType(UIButtonType.RoundedRect);
            buttonClasses.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                buttonGetCerts.Frame.Y + buttonHeight,
                buttonWidth,
                buttonHeight);
            buttonClasses.SetTitle("Get classes", UIControlState.Normal);

            // Handle button touch
            buttonClasses.TouchUpInside += (object sender, EventArgs e) =>
            {
                // Prepate action sheet
                var actionSheet = new UIActionSheet("Select class type");
                
                // Add button for each class type
                foreach (var typ in Enum.GetNames(typeof(Common.Model.ClassType)))
		            actionSheet.AddButton(typ);

                // Handle sheet clicked
                actionSheet.Clicked += async delegate(object sender2, UIButtonEventArgs e2){
                    
                    // Make sure user didn't dismiss action sheet
                    if (e2.ButtonIndex != -1)
                    {
                        // Get selected type
                        var title = ((UIActionSheet)sender2).ButtonTitle(e2.ButtonIndex);
                        var selectedClassType = (Common.Model.ClassType)Enum.Parse(typeof(Common.Model.ClassType), title, true);
                        
                        // Call API and get classes available for selected type
                        var classes = await new Api(url).GetClassesAsync(selectedClassType);

                        // Process classes returned
                        if (classes != null)
                        {
                            Alert("", "Classed found: " + classes.Count);

                            foreach (var cls in classes)
                                Console.WriteLine("Code: {0}, Name: {1}, Description: {2}", cls.Code, cls.Name, cls.Description);
                        }
                    }

                };
                actionSheet.ShowInView(this.View);
            };
            
            buttonClasses.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin;
            View.AddSubview(buttonClasses);
            #endregion

            #region Upload Model button

            // Setup button UI
            buttonUploadNewClass = UIButton.FromType(UIButtonType.RoundedRect);
            buttonUploadNewClass.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                buttonClasses.Frame.Y + buttonHeight,
                buttonWidth,
                buttonHeight);
            buttonUploadNewClass.SetTitle("Upload new class", UIControlState.Normal);

            // Handle button touch
            buttonUploadNewClass.TouchUpInside += async (object sender, EventArgs e) =>
            {
                // Create new class to upload
                var newClass = new Common.Model.Class()
                {
                    Code = "[IOS104]",
                    Description = "Intro to RESTful Web Services with iOS",
                    Name = "Teaches how to integrate with and use web services in iOS."
                };

                // Call API and upload new class
                var success = await new Api(url).UploadNewClass(newClass);
                
                Alert("New Class Upload", (success ? "Success" : "Failed"));
            };

            buttonUploadNewClass.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin;
            View.AddSubview(buttonUploadNewClass);
            #endregion
        }

        public static void Alert(string title, string message)
        {
            UIAlertView alert = new UIAlertView();
            alert.Title = title;
            alert.Message = message;
            alert.AddButton("OK");
            alert.Show();
        }
    }
}

