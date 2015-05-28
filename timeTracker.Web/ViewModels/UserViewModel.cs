using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using timeTracker.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace timeTracker.Web.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }

        public IEnumerable<SelectListItem> AllUsers { get; set; }
    }

    public class GroupedUserViewModel
    {
        public List<UserViewModel> Users { get; set; }
        
    }

    public class EditUserViewModel
    {
        public EditUserViewModel(UserViewModel user)
        {
            this.UserName = user.Username;
            this.Role = user.Role;
            this.Department = user.Department;
            this.Email = user.Email;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Email { get; set; }
    }
}