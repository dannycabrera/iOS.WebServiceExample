using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iOS.WebServiceExample.Common
{
    public class Data
    {
        public IEnumerable<Model.Certificate> GetCertificates()
        {
            return new List<Model.Certificate>()
            {
                new Model.Certificate() { Name = "iOS Developer" },
                new Model.Certificate() { Name = "Android Developer" },
                new Model.Certificate() { Name = "Mobile Developer" }
            };
        }

        public IEnumerable<Model.Class> GetClasses(Common.Model.ClassType type)
        {
            var classes = new List<Model.Class>()
            {
                new Model.Class() { Code = "[XAM101]", Type=Model.ClassType.XPlat, Name = "Intro to Mobile/Kickstart", Description = "A quick introduction to Xamarin and Mobile Development. Covers the Mobile Application Development Lifecycle, including publishing options, Xamarin tools, etc." },
                new Model.Class() { Code = "[AND101]", Type=Model.ClassType.Android, Name = "Intro to Android with Xamarin Studio", Description = "Introduces Android development. Covers basic app creation, creating multi-screen apps with Activities, Android Resource usage, deployment, debugging, and other app fundamentals." },
                new Model.Class() { Code = "[AND102]", Type=Model.ClassType.Android, Name = "Intro to Android with Visual Studio", Description = "Same as Intro to Android with Xamarin Studio, but uses VS as the development environment." },
                new Model.Class() { Code = "[IOS101]", Type=Model.ClassType.iOS, Name = "Intro to iOS with Xamarin Studio", Description = "Introduces iOS development. Covers basic app creation, creating multi-screen apps with iOS’s MVC pattern, deployment, debugging, and introduces app fundamentals." },
                new Model.Class() { Code = "[IOS102]", Type=Model.ClassType.iOS, Name = "Intro to iOS with Visual Studio", Description = "Essentially the same as Intro to iOS with Xamarin Studio, but uses VS as the development environment and discusses VS specific concerns." },
                new Model.Class() { Code = "[AND110]", Type=Model.ClassType.Android, Name = "List Views and Adapters in Android", Description = "Teaches how to populate and use List Views including population, customization, selection, and more." },
                new Model.Class() { Code = "[IOS110]", Type=Model.ClassType.iOS, Name = "Tables and Collection Views in iOS", Description = "Teaches how to use Tables (and their more expressive counterpart - UICollectionViews), including populating, handling selection, editing, and customizing appearance." },
                new Model.Class() { Code = "[XAM140]", Type=Model.ClassType.XPlat, Name = "Introduction to Cross-Platform Mobile Development", Description = "Meant as a follow up to the Intro to iOS and Android classes, this course introduces how to create solutions that have multiple platform targeted applications and how to maximize code sharing between them." },
                new Model.Class() { Code = "[XAM150]", Type=Model.ClassType.XPlat, Name = "Introduction to Cross-Platform Web Services", Description = "Teaches how to integrate with and use web services in mobile applications. Provides an introduction to RESTful, WCF, and WSDL web service integration, as well as recommendations for new web service projects, and libraries to make web service access easier." },
                new Model.Class() { Code = "[XAM160]", Type=Model.ClassType.XPlat, Name = "Data in Mobile", Description = "Provides a solid introduction and comparison to data access and persistence in mobile apps. Covers using the native SQLite in iOS and Android, Managed SQLite in Windows Marketplace Apps, and two of the most common technologies to access them; SQLite.NET ORM and ADO.NET." },
                new Model.Class() { Code = "[XAM205]", Type=Model.ClassType.XPlat, Name = "Mobile Navigation Patterns", Description = "Introduces the most common user interface navigation metaphors on iOS, Android, and Windows Phone. Also examines the most appropriate uses for each and how to implement them in Xamarin apps." },
                new Model.Class() { Code = "[XAM210]", Type=Model.ClassType.XPlat, Name = "Backgrounding", Description = "Discusses how to perform background tasks on both iOS and Android, ensuring your apps remain responsive and can complete important operations even when they aren't visible to the user." },
                new Model.Class() { Code = "[XAM300]", Type=Model.ClassType.XPlat, Name = "Advanced Cross-Platform Development", Description = "Picks up where the Intro to Xplat class left off and introduces a number of advanced cross platform frameworks and patterns." },
                new Model.Class() { Code = "[XAM427]", Type=Model.ClassType.XPlat, Name = "Enterprise WCF Integration", Description = "Explains Xamarin's support for consuming WCF services that use the BasicHttpBinding, including configuring a WCF service and creating proxy classes that can be incorporated into iOS and Android applications. This course will require Visual Studio 2012/2013 that has Xamarin.iOS or Xamarin.Android configured." },
                new Model.Class() { Code = "[XAM370]", Type=Model.ClassType.XPlat, Name = "Memory Management + Best Practices", Description = "Introduces the garbage collector and provides specific advice for both iOS and Android applications to ensure your apps use memory efficiently. Also covers linking and how to diagnose memory issues." },
                new Model.Class() { Code = "[XAM220]", Type=Model.ClassType.XPlat, Name = "Publishing an App", Description = "Walks through the process of building apps for release on the App Store and Google Play, including certificate setup, code-signing, packaging considerations and even guidelines for icon design and writing your app's description." },
                new Model.Class() { Code = "[IOS301]", Type=Model.ClassType.iOS, Name = "Advanced iOS UI", Description = "his class takes a more in-depth look at storyboards, resizing constraints, creating a UI programmatically, handling different screen sizes, and a number of other advanced iOS UI techniques." },
                new Model.Class() { Code = "[AND301]", Type=Model.ClassType.Android, Name = "Advanced Android UI", Description = "This class builds on the core lessons of UI development learned in the fundamentals course and takes it further, examining how to optimize Android UI Layouts, how to use Fragments, and more." },
                new Model.Class() { Code = "[XAM230]", Type=Model.ClassType.XPlat, Name = "Maps and Location", Description = "Maps and location in the palm of our hands have changed the way that we interact with the world. It's had to imagine navigating without our smartphone these days. in this course we'll examine how to embed and use mapping frameworks within our applications, as well as how to get location data, do map overlays, and more." },
                new Model.Class() { Code = "[XAM410]", Type=Model.ClassType.XPlat, Name = "Data Caching + Synchronization", Description = "Being disconnected from the cloud but caching local data that synchronizes upon reconnection is a common scenario in Enterprise applications. In this class we're going to look at the change of local data caching and synchronization from a general problem, and then examine some frameworks that attempt to solve this challenge." },
                new Model.Class() { Code = "[XAM240]", Type=Model.ClassType.XPlat, Name = "Touch in Mobile", Description = "Capacitive Multitouch interfaces on smartphones have become a staple. But using them effectively can be a challenge. This class examines how touch works across both iOS and Android and covers touch lifecycle events, built-in gestures, and creating custom gestures that will enhance the UX of your apps." }
            };

            return (from c in classes where c.Type == type select c);
        }
    }
}
