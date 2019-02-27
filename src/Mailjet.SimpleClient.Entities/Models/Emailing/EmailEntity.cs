using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    /// <summary>
    /// An EmailEntity may be a recipient or a sender
    /// </summary>
    /// <remarks>I.e. anything that has a name and an email</remarks>
    public class EmailEntity : IEmailEntity
    {
        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="name">Name of the entity</param>
        /// <param name="email">Email of the entity</param>
        public EmailEntity(string name, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Name { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Parses a string into an EmailEntity
        /// </summary>
        /// <param name="emailString">Email string, e.g. Person Perssonsen <person@perssonsen.com></param>
        /// <returns>Returns null if string couldn't be parsed</returns>
        public static EmailEntity Parse(string emailString)
        {
            var match = Regex.Match(emailString, @"^(?'Name'.*)\s<(?'Email'.*@.*)>$");
            if (!match.Success) return null;
            return new EmailEntity(match.Groups["Name"].Value, match.Groups["Email"].Value);
        }

    }
}
