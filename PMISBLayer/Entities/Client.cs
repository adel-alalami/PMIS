using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientCity { get; set; }
        public string ClientStreetAddress{ get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientFax { get; set; }
    }
}
