Introduction
-------
This sample shows how to connect to ASP.Net Web API from Xamarin.iOS to GET and POST some data.
![AppScreenshot](Screenshots/Application.png)
![GetCertificates](Screenshots/GetCertificates.png)
![GetClassesByType](Screenshots/GetClassesByType.png)


Setup
-------
1. All projects were created using Visual Studio 2013
2. On iOS.WebServiceExample.iPhoneApp MyViewController.cs change the variable url to your local address so that the iPhone app can locate your Web API instance.
3. For my local testing I created a virtual directory to run the Web API
![WebAPIProjectWebSettings](Screenshots/WebAPIProjectWebSettings.png)


Details
-------
1. Solution consists of 3 projects
	![](Screenshots/SolutionOverview.png)

	- iOS.WebServiceExample.Common (Data model & sample data taken from http://xamarin.com/university)
	
	- iOS.WebServiceExample.iPhoneApp (Xamarin.iOS application)
	The app consists of 3 buttons that call the Web API methods asynchronously.
	
	- iOS.WebServiceExample.WebAPI (ASP.Net Web API)
	The Test controller exposes 3 methods, 2 GET and 1 POST.
	![WebAPI](Screenshots/WebAPI.png)


Xamarin Components Used
-------
[Json.NET](http://components.xamarin.com/view/json.net/)