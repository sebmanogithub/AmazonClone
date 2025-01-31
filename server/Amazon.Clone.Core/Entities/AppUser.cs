using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Clone.Core.Entities.Common;

namespace Amazon.Clone.Core.Entities
{
    public class AppUser : BaseEntity
    {
        [Key]
        public string UserName { get; set; }
        // public string Email { get; set; }
        // public string PasswordHash { get; set; }
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public string PhoneNumber { get; set; }
        // public DateTime DateOfBirth { get; set; }
        // public DateTime Created_at { get; set; }
        // public DateTime Updated_at { get; set; }
    }
}