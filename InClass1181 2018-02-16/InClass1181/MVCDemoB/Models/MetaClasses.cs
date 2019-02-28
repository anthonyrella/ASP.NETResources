using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVCDemoB.Models
{
    public class MemberMetaData
    {
        [Display(Name = "Member Name")]
        [Required(ErrorMessage = "Member name is required.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Membe name must be between 3 to 15 characters.")]
        public string Name { get; set; }
    }

    public class GameMetaData
    {
        public string Title { get; set; }
        public string Studio { get; set; }
    }
}