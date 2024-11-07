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
                return true;
            }
            else
            {
                await client.Child("Prov").PostAsync(users);
                return true;
            }




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
                    GlobalVariables.email = Username;
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
    }
}
