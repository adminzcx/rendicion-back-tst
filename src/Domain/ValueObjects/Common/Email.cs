using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Prome.Viaticos.Server.Domain.ValueObjects.Common
{
    public class Email
    {
        public Email()
        {
            SendToEmailList = new Collection<string>();
            SendCCToEmailList = new Collection<string>();
            SendBCCToEmailList = new Collection<string>();
            AttachmentsPath = new Collection<string>();
        }

        public string EmailSubject { get; set; }

        public IList<string> SendToEmailList { get; set; }

        public ICollection<string> SendCCToEmailList { get; set; }

        public ICollection<string> SendBCCToEmailList { get; set; }

        public string Subject { get; set; }

        public string BodyMessage { get; set; }

        public ICollection<string> AttachmentsPath { get; set; }

    }
}