using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstBackend.ViewModels.Result
{
    public class RApplicationUserListVm
    {
        public ApiResultVm Result { get; set; }
        public List<ApplicationUserVm> Data { get; set; }
    }
}
