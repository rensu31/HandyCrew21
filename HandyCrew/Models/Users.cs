using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

using Firebase.Database;
using Firebase.Storage;
using Firebase.Database.Query;
using HandyCrew.Includes;
using static HandyCrew.Includes.GlobalVariables;

namespace HandyCrew.Models
{
    class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string selectedaccs { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string ImageProf { get; set; }

        public string Userss { get; set; }
        public string Pass { get; set; }




        public async Task<bool> _SignUp(String FirstName, String LastName,String selectedaccs, string Username, string Password)
        {
            var users = new Users()
            {

                FirstName = FirstName,
                LastName = LastName,
                selectedaccs = selectedaccs,
                Username = Username,
                Password = Password

            };


          
            if (selectedaccs == "Homeowner")
            {
                await client.Child("Users").PostAsync(users);
                GlobalVariables.Selectedacc = selectedaccs; 
                return true;



            }
            if (selectedaccs == "Service Provider")
            {
                await client.Child("Prov").PostAsync(users);
                GlobalVariables.Selectedacc = selectedaccs;
                return true;
              

            }

            return false;

        }



        public async Task<string> GetSignUserByFirstNameAndLastName(string Username)
        {
            var users = await client.Child("Prov").OnceAsync<Users>();
            var userWithKey = users.FirstOrDefault(u => u.Object.Username.Equals(Username, StringComparison.OrdinalIgnoreCase));
            return userWithKey?.Key;
        }

        public async Task<string> GetSignUserByFirstNameAndLastName1(string Username)
        {
            var users = await client.Child("User").OnceAsync<Users>();
            var userWithKey = users.FirstOrDefault(u => u.Object.Username.Equals(Username, StringComparison.OrdinalIgnoreCase));
            return userWithKey?.Key;
        }

        public async Task<bool> _GetUserprov(string _Username, string _Password)
        {
            try
            {
                var evaluateUsername =
                    (await client.Child("Prov").OnceAsync<Users>()).FirstOrDefault(a =>
                        a.Object.Username == _Username && a.Object.Password == _Password);
                if (evaluateUsername != null)
                {
                    return true;
                    
                }
                else
                {

                    return false;
                }

            }
            catch
            {
                return false;
            }

            

        }

        public async Task<bool> _GetUser(string _Username, string _Password)
        {
            try
            {
                var evaluateUsername =
                    (await client.Child("Users").OnceAsync<Users>()).FirstOrDefault(a =>
                        a.Object.Username == _Username && a.Object.Password == _Password);
                if (evaluateUsername != null)
                {
                   
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch
            {
                return false;

            }
        }

        public async Task<bool> GetUsername(String _Username)
        {
            try
            {
                var evaluateUsername =
                    (await client.Child("Users").OnceAsync<Users>()).FirstOrDefault(b =>
                        b.Object.Username == _Username);
                if (evaluateUsername != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

            catch
            {
                return false;
            }

        }

        public async Task<string> UploadProfImage(Stream img, string filename)
        {
            try
            {
                //var image = await storage
                //    .Child($"Images/PostImages/{filename}")
                //    .PutAsync(img);
                var image = await storage.Child($"Images/Profiles/{filename}").PutAsync(img);
                return image;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error uploading image: {e.Message}");

                return "false";
            }


        }

        public async Task<bool> _AddProf(String address, FileResult mainimg, string flename)
        {
            var idprof = GlobalVariables.email;
            var selected = GlobalVariables.Selectedacc;
            var _mainimg = await UploadProfImage(await mainimg.OpenReadAsync(), $"{flename}_mainimg.png");
            var users = new Users()
            {

                Address = address,
                ImageProf = _mainimg


            };



            if (selected == "Homeowner")
            {
                await client.Child($"Users/{idprof}").PatchAsync(users);
                return true;




            }
            if (selected == "Service Provider")
            {
                await client.Child($"Prov/{idprof}").PatchAsync(users);
                return true;

            }



            return false;

        }



    }
}
