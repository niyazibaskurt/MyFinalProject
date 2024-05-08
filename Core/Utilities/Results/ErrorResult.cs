using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //Mesaj var base'e iki parametre gönder
        public ErrorResult(string message) : base(false, message)
        {

        }

        //Mesaj yok base'e tek parametre gönder
        public ErrorResult() : base(false)
        {

        }
    }
}
