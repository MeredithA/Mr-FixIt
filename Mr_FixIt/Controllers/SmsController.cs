using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.Clients;
//using Twilio.Types;

namespace Mr_FixIt.Controllers
{
    public class SmsController : Controller
    {
        //public ActionResult SmsNotification()
        //{
            
        //}

    }









    //[HttpPost]
    //public TwiMLResult Index()
    //{
    //    var client = new ITwilioRestClient {(
    //        Environment.GetEnvironmentVariable("AC96dcd364a141048f38dd805e4dae1e22"),
    //        Environment.GetEnvironmentVariable("9e4814060f0ed9a91e2fadcf3e34129c")
    //        );
    //    client.SendMessage(
    //        Environment.GetEnvironmentVariable("1312878976"),
    //        Environment.GetEnvironmentVariable("17087400366"), "Your request has been updated",

    //        return View();
    //            )
    //    }











    //String AccountSid = "AC96dcd364a141048f38dd805e4dae1e22"; // Account ID..
    //String AuthToken = "9e4814060f0ed9a91e2fadcf3e34129c"; // Authentication Tocken.. 
    //String TelephoneNo = "13128789761"; // Telephone No from the message will sent.      only had ' in 



    //static void Main(string[] args)
    //{
    //    TwilioClient.Init(
    //        Environment.GetEnvironmentVariable("AC96dcd364a141048f38dd805e4dae1e22"),
    //        Environment.GetEnvironmentVariable("9e4814060f0ed9a91e2fadcf3e34129c"));

    //    MessageResource.Create(
    //        to: new PhoneNumber("+17087400366"),
    //        from: new PhoneNumber("+1312878976"),
    //        body: "Your request has been updated.");
    //}






    //static void Main(string[] args)
    //{
    //    // Find your Account Sid and Token at twilio.com/console
    //    const string accountSid = "AC96dcd364a141048f38dd805e4dae1e22";
    //    const string authToken = "9e4814060f0ed9a91e2fadcf3e34129c";

    //    TwilioClient.Init(accountSid, authToken);

    //    var message = MessageResource.Create(
    //        body: "Your work request has been updated.",
    //        from: new Twilio.Types.PhoneNumber("+13128789761"),
    //        to: new Twilio.Types.PhoneNumber("+17087400366"),
    //        pathAccountSid: "AC96dcd364a141048f38dd805e4dae1e22"
    //    );

    //    Console.WriteLine(message.Sid);
    //}

    //public String TestTwilio(SmsModel obj)
    //{
    //    obj.Sender = "sender approved number";
    //    var client = new TwilioRestClient("ACCOUNT SID", "AUTH TOKEN");
    //    var result = client.SendMessage(obj.Sender, obj.Reciever, obj.Message);

    //    return result.ToString();
    //}










    //        public partial class _default : System.Web.UI.Page
    //        {
    //            protected void Page_Load(object sender, EventArgs e)
    //            {
    //            }

    //            protected void SendMessage_OnClick(object sender, EventArgs e)
    //            {
    //                string ACCOUNT_SID = System.Configuration.ConfigurationManager.AppSettings["AC96dcd364a141048f38dd805e4dae1e22"];
    //                string AUTH_TOKEN = System.Configuration.ConfigurationManager.AppSettings["9e4814060f0ed9a91e2fadcf3e34129c"];

    //                TwilioRestClient client = new TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN);

    //                var message = MessageResource.Create(
    //                body: "Your work request has been updated.",
    //                from: new Twilio.Types.PhoneNumber("+13128789761"),
    //                to: new Twilio.Types.PhoneNumber("+17087400366"),
    //                pathAccountSid: "AC96dcd364a141048f38dd805e4dae1e22"
    //);
    //            }
    //        }


}