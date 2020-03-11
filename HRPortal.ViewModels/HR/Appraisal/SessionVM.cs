using HRPortal.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.ViewModels.HR.Appraisal
{
    public class SessionVM
    {
        public int? SessionID { get; set; }

        [Required(ErrorMessageResourceName = "ErrRequired", ErrorMessageResourceType =typeof(LocalizedStrings))]
        [MinLength(5,ErrorMessage ="* Session name too short !")]
        public string SessionName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string StartedBy { get; set; }

        public string ClosedBy { get; set; }

        public string Notes { get; set; }

        public bool? Active { get; set; }

        public bool? Published { get; set; }
    }
}
