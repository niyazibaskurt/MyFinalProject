using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{    //data ve mesaj verildiğinde veya sadece data verildiğinde veya sadece mesaj verildiğinde veya en son her ikiside verilmediğinde 
    public class SuccessDataResult<T> : DataResult<T>
    { 
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        //Data vermezsek, data base'e default olarak gönderilir.

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}