
using System.Collections.Generic;

namespace Bai2MVc.Services{

    // public interface IBookListStore{
    //     public List<string> ListPlace();
    // }
    public class BookListStore{
        public List<string> ListPlace(){
            return new List<string>{
                "Bac Giang",
                "Ha Noi",
                "Cao Bang",
                "Hai Phong"

            };
        }
    }
}