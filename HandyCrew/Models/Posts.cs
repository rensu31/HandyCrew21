using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Database.Query;
using static HandyCrew.App;
using static HandyCrew.Includes.GlobalVariables;
using HandyCrew.Includes;

namespace HandyCrew.Models
{
     class Posts
    {

        public string Email { get; set; }
        public string TitlePost { get; set; }
        public string Description { get; set; }
        public string SelectedItem { get; set; }
        public string Image { get; set; }


        public async Task<string> UploadImage(Stream img, string filename)
        {
            try
            {
                //var image = await storage
                //    .Child($"Images/PostImages/{filename}")
                //    .PutAsync(img);
                var image = await storage.Child($"Images/PostImages/{filename}").PutAsync(img);
                return image;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error uploading image: {e.Message}");

                return "false";
            }


        }

        public async Task<bool> Addimage(
                FileResult mainimg, string flename)
            //MediaFile img1, MediaFile img2, string propCategory, string propStatus,
            //MediaFile img3, MediaFile img4, MediaFile img5, MediaFile img6
        {
            try
            {

                //Save Listing images
                var _mainimg = await UploadImage(await mainimg.OpenReadAsync(), $"{flename}_mainimg.png");

                client.Dispose();
                return false;
            }
            catch
            {
                client.Dispose();
                return false;
            }

        }
        public async Task<bool> _AddPost( String titlepost, String description, string selectedItem ,
             FileResult mainimg, string flename)
        {
            var _mainimg = await UploadImage(await mainimg.OpenReadAsync(), $"{flename}_mainimg.png");
            var provemail = GlobalVariables.email;
           
            var Post = new Posts()
            {
                Email = provemail,
                TitlePost = titlepost,
              Description = description,
              SelectedItem = selectedItem,
              Image = _mainimg
            };
            
            await client.Child("Posts").PostAsync(Post);
            return true;


        }


      


    }
}
