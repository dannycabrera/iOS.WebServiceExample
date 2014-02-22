iOS.WebServiceExample
=====================

Xamarin.iOS Web Service Example

Introduction
-------
This sample shows how to connect to ASP.Net Web API from Xamarin.iOS to GET and POST some data.

Setup
-------
1. On iOS.WebServiceExample.iPhoneApp MyViewController.cs change the variable url to point to your Web API.
2. For my local testing I created a virtual directory to run the Web API
![WebAPIProjectWebSettings](Screenshots/WebAPIProjectWebSettings.png)


Details
-------
1. Solution consists of 3 projects
	- iOS.WebServiceExample.Common (Data model & sample data)
	- iOS.WebServiceExample.iPhoneApp (Xamarin.iOS application)
	- iOS.WebServiceExample.WebAPI (ASP.Net Web API)

	
Screenshots
-------
![AppScreenshot](Screenshots/App.png)
![GetCertificates](Screenshots/GetCertificates.png)
![GetClassesByType](Screenshots/GetClassesByType.png)
![WebAPI](Screenshots/WebAPI.png)
-------

Xamarin Components Used
-------
[Json.NET](http://components.xamarin.com/view/json.net/)