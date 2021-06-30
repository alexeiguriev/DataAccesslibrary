using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslibrary.Models
{
    public enum UserField
    {
        Id,
        FirstName,
        LastName,
        EmailAddress,
        Password
    }
    public class USER
    {
        /// <summary>
        /// The unic identifier for person.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Represents the last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the email addres
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Represents the Password
        /// </summary>
        public string Password { get; set; }
    }
}
