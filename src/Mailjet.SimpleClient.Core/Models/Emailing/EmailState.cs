using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public enum EmailState
    {
        /// <summary>
        /// "user unknown (recipient)"
        /// </summary>
        RecipientUnknown = 1,
        /// <summary>
        /// mailbox inactive (recipient)
        /// </summary>
        RecipientMailboxInactive = 2,
        /// <summary>
        /// quota exceeded (recipient)
        /// </summary>
        RecipientQuotaExceeded = 3,
        /// <summary>
        /// invalid domain (domain)
        /// </summary>
        InvalidDomain = 4,
        /// <summary>
        /// no mail host (domain)
        /// </summary>
        NoMailHost = 5,
        /// <summary>
        /// relay/access denied (domain)
        /// </summary>
        RelayDenied = 6,
        /// <summary>
        /// sender blocked (spam)
        /// </summary>
        SenderBlocked = 7,
        /// <summary>
        /// content blocked (spam) 
        /// </summary>
        ContentBlocked = 8,
        /// <summary>
        /// policy issue (spam)
        /// </summary>
        PolicyIssue = 9,
        /// <summary>
        /// system issue (system)
        /// </summary>
        SystemIssue = 10,
        /// <summary>
        /// protocol issue (system)
        /// </summary>
        ProtocolIssue = 11,
        /// <summary>
        /// connection issue (system)
        /// </summary>
        ConnectionIssue = 12,
        /// <summary>
        /// graylisted (domain)
        /// </summary>
        DomainGraylisted = 13,
        /// <summary>
        /// preblocked (Mailjet)
        /// </summary>
        PreblockedMailjet = 14,
        /// <summary>
        /// duplicate in campaign (Mailjet)
        /// </summary>
        CampaignDuplicate = 15,
        /// <summary>
        /// spam preblocked (Mailjet)
        /// </summary>
        PreblockedSpam = 16,
        /// <summary>
        /// bad or empty template (content)
        /// </summary>
        BadTemplate = 17,
        /// <summary>
        /// error in template language (content)
        /// </summary>
        TemplateLanguageError = 18,
        /// <summary>
        /// typofix (domain)
        /// </summary>
        Typofix = 19,
        /// <summary>
        /// blacklisted (recipient)
        /// </summary>
        RecipientBlacklisted = 20,
        /// <summary>
        /// spam reporter (recipient)
        /// </summary>
        SpamReporter = 21
    }
}
