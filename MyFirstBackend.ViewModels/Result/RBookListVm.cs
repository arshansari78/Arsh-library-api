using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstBackend.ViewModels.Result
{
    public class RBookListVm
    {
        public ApiResultVm Result { get; set; }



        public List<BookVm> Data { get; set; }
    }
}
