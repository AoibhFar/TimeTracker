using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace timeTracker.Web.Models
{
    public class CreateTimeSheetEntryViewModel
    {
        [Key]
        public int Id { get; set; }
    
    }
}