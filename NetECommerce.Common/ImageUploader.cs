using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.Common
{
    public class ImageUploader
    {
        public static string ImageChangeName(string imageName)//c#_logo.png
        {
            //1=> uymayan format

            string newFileName = "";

            var uniqueName=Guid.NewGuid().ToString();

            var fileArray=imageName.Split('.'); //[0]=c#_logo [1]=.png

            var extension = fileArray[fileArray.Length - 1];

            // parametre alınan imageName (.png .jpg .jpeg .gif .svg .bmp .webp) görsel bir uzantıya sahip olmalı gerekli

            if (extension == "png" || extension == "jpeg" || extension == "jpg")
            {


                newFileName = uniqueName + "." + extension;

                return newFileName;
            }
            else
            {
                return "1";
            }


           

        }
    }
}
