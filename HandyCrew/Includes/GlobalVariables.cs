using Firebase.Database;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HandyCrew.Includes
{
    class GlobalVariables
    {
        public static FirebaseClient client = new("https://handycrew-bd623-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseStorage storage = new("handycrew-bd623.appspot.com");
        public static string email,Fullname;
        public static string SignId;
        public static string GetID;
        public static string Selectedacc;
        public static double Lated,Loted;
      
    }
}
