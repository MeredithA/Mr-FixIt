using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Mr_FixIt.Api
{
    public class TwilioNotification
    {
        static void Main(string[] args)
        {
            TwilioClient.Init(
                Environment.GetEnvironmentVariable("AC96dcd364a141048f38dd805e4dae1e22"),
                Environment.GetEnvironmentVariable("9e4814060f0ed9a91e2fadcf3e34129c"));

            MessageResource.Create(
                to: new PhoneNumber("+17087400366"),
                from: new PhoneNumber("+1312878976"),
                body: "Your request has been updated.");
        }
    }
}


//https://www.twilio.com/blog/2016/04/send-an-sms-message-with-c-in-30-seconds.html