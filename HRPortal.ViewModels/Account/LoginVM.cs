using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.ViewModels.Account
{
    public class LoginVM
    {

        [Required(ErrorMessage = "&nbsp;*")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "&nbsp;*")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
