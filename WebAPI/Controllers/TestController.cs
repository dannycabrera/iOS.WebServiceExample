using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web;

namespace iOS.WebServiceExample.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        [Route("api/test/getCertificates"), AcceptVerbs("GET")]
        public IEnumerable<Common.Model.Certificate> GetCertificates()
        {
            return new Common.Data().GetCertificates();
        }

        [Route("api/test/GetClasses"), AcceptVerbs("GET")]
        public IEnumerable<Common.Model.Class> GetClasses(Common.Model.ClassType type)
        {
            return new Common.Data().GetClasses(type);
        }

        [Route("api/test/SaveClass"), AcceptVerbs("POST")]
        public HttpResponseMessage SaveClass([FromBody]Common.Model.Class xamClass)
        {
            Console.WriteLine("Received: {0}", xamClass.Name);

            // Do something with the newly saved class...

            // Let the client app know the save was successful
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}
