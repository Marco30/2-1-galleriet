using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace _1DV406_Labb2_1.Model// Marco villegas
{
    public class GalleryClass
    {

        // Fält för att ge bilden fokus.
        public string Class;
        public string Name;

        //Fält som kommer att användas
        private readonly static Regex ApprovedExtensions;// // Fält som undersöker om en fil har tillåten filändelse med hjälp av reguljärt uttryck
        private readonly static Regex SantizePath; // kommer användas för att se till att filnamn innehåller godkända tecken med hjälp av reguljärt uttryck 
        private readonly static string Bildsokveg;// kommer ha fysiska sökvägen till bilderna som laddatupp
        private readonly static string thumbnailssokveg;// kommer ha fysiska sökvägen tilll thumbnagel bilderna 

        static GalleryClass()// Konstruktor
        {
            ApprovedExtensions = new Regex(@"([^\s]+(\.(?i)(jpg|png|gif))$)", RegexOptions.IgnoreCase);//reguljära uttryck sätts 
            var invalidChars = new string(Path.GetInvalidFileNameChars());// hämtar en array som innehåller de tecken som inte är tillåtna i filnamn
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));// reguljära uttryck sätt

            //SantizePath = new Regex(string.Format("[0-9]", Regex.Escape(invalidChars))); test

            Bildsokveg = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Bilder");// fysiska sökvägen
            thumbnailssokveg = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Bilder/thumbnails/");// fysiska sökvägen
        }

        public IEnumerable<GalleryClass> GetImageNames()// Funktion som returnerar en referens med bildernas filnamn sorterade i bokstavsordning
        {

            var dir = new DirectoryInfo(thumbnailssokveg);// hämtar alla thumbnagel bilderna 

            return (from files in dir.GetFiles()
                    select new _1DV406_Labb2_1.Model.GalleryClass
                    {
                        Name = files.Name,
                        Class = "imageBorder"
                    }).OrderBy(files => files.Name).ToList(); // sorterade i bokstavsordning och returnar dem
        }


        public static bool ImageExists(string name)// funktion som kontrollerar om en bild redan existerar i mappen för de uppladdade bilderna
        {
            return File.Exists(Path.Combine(Bildsokveg, name));
        }


        private bool IsValidImage(Image image)// funktion som kontrollerar om den uppladdade bilden är av rätt fil typ gif, jpg eller png
        {
            if (image.RawFormat.Guid == ImageFormat.Gif.Guid || image.RawFormat.Guid == ImageFormat.Jpeg.Guid || image.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string SaveImage(Stream stream, string fileName)// i den här funktion så gör man tre saker man verifierar, kontrollerar och sparar bild samt skapar och sparar en tumnagelbild
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            //SantizePath.Replace(fileName, "Marco");

            if (!IsValidImage(image))// kallar på funktionen som Kontrollerar om bilden är av rätt filtyp.
            {
                throw new ArgumentException("Filen är inte ett giltigt filtyp, .gif, .jpg, .png stöds");
            }

            if (SantizePath.IsMatch(fileName))// Kontrollerar att filen inte har några otillåtna tecken i filnamnet.
            {
                throw new ArgumentException("Filen har illegala tecken i filnamnet");
            }

            if (!ApprovedExtensions.IsMatch(fileName))// kallar på funktionen som Kontrollerar om bilden är av rätt filtyp.
            {
                throw new ArgumentException("Bilden måste vara av typen jpeg, gif eller png.");
            }

            if (ImageExists(fileName))//  Kallar på funktion som Kontrollerar om en bild med samma namn finns
            {

                while (ImageExists(fileName))// om den finns så läger vi till ett nytt täcken i while loppen 
                {
                    fileName = "Marco" + fileName;
                }
            }


            image.Save(Path.Combine(Bildsokveg, fileName));// bilden har klarat alla valideringar, bilden sparas  

            System.Drawing.Image thumbnail = image.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);//Här setter vi storläk på tumnagel bilden med hjälp av image.GetThumbnailImage(
            thumbnail.Save(Path.Combine(thumbnailssokveg, fileName));//Här sparar vi tumnagel bilden 

            return fileName;
        }


       
    }
}