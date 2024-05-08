using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç 
    //Burda işlem başarılı mı değil mi ve işlem mesajları ne bunlar yer alacak.

    public interface IResult
    {
        bool Success { get; }

        string Message { get; }
    }
}
