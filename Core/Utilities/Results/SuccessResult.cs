using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //Mesaj var base'e iki parametre gönder
        public SuccessResult(string message) : base(true, message)
        {

        }

        //Mesaj yok base'e tek parametre gönder
        public SuccessResult() : base(true)
        {

        }

    }
}
