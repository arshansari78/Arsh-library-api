using System;
using System.Collections.Generic;
using System.Text;
using MyFirstBackend.ViewModels.Common; 
using MyFirstBackend.ViewModels;


namespace MyFirstBackend.ViewModels.Result
{
    public class RAllotmentListVm
    {
        public ApiResultVm Result { get; set; }

        public List<AllotmentVm> Data { get; set; }
    }
}
