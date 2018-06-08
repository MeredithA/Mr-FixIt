using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Mr_FixIt.Models
{
    public static class TwilioApi
    {
        static private string accountSid = "AC96dcd364a141048f38dd805e4dae1e22";
        static private string authToken = "9e4814060f0ed9a91e2fadcf3e34129c";

        static public void Send(Ticket ticket)
        {
            TwilioClient.Init(accountSid, authToken);
            ApplicationDbContext db = new ApplicationDbContext();
            int tenantId = (from row in db.TicketTenantJunctions where row.TicketId == ticket.ID select row.TenantId).First();
            Tenant tenant = (from row in db.Tenants where row.ID == tenantId select row).First();
            var message = MessageResource.Create(
                body: $"Your work request has been updated. Status is {ticket.UpdateNote}.",
                from: new Twilio.Types.PhoneNumber("+13128789761"),
                to: new Twilio.Types.PhoneNumber($"+1{tenant.PhoneNumber}"),
                pathAccountSid: "AC96dcd364a141048f38dd805e4dae1e22"
                );
        }
    }
}