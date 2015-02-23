using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1DV406_Labb2_1.Model;
using System.IO;

namespace _1DV406_Labb2_1// Marco villegas
{
    public partial class Default : System.Web.UI.Page
    {

        private GalleryClass _galleryClass;// Fält


        private GalleryClass Gallery// Egenskap
        {
            get
            {
                return _galleryClass ?? (_galleryClass = new GalleryClass());//  om _galleryClass är null så Skapar nytt object och lägger den i
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //hämtar fysisnka sökvägen ur QueryString
            if (Request.QueryString["Picture"] != null)//om QueryStringär lika med null så hämtar bilden för att visas i större format 
            {
                SelectedImage.ImageUrl = String.Format("/Bilder/{0}", Request.QueryString["Picture"]);
            }


            if (Session["lyckades"] != null)//Skriver ut att upplandning av bild lyckades om sesion lika med null 
            {
                StatusMessage.Text = Session["lyckades"].ToString();
                Message.Visible = true;
                Session["lyckades"] = null;
                //Session.Remove("lyckades");
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // If a file is beeing uploaded, the galleryclass is contacted to validate and save the image, plus create thumbnails.
                if (PictureUpload.HasFile)// fil laddas upp
                {
                    try//Fel hantering 
                    {
                        Gallery.SaveImage(PictureUpload.FileContent, PictureUpload.FileName);//galleriet klassen kontaktas för att validera och spara bilden, plus skapa miniatyrer.
                        Session["lyckades"] = "Bild Uppladdningen lyckades";// sesion får texten Bild Uppladdningen lyckades
                        Response.Redirect(String.Format("~/Default.aspx?Picture={0}", PictureUpload.FileName));// ladar om sidan och nu med bilden i stort format och med miniatyr
                    }
                    catch (Exception)// Fel hanteras här med ett fel meddelande 
                    {
                        ModelState.AddModelError("ERROR", "Fel inträffade vid upladdning");
                    }
                }
            }
        }


        public IEnumerable<GalleryClass> GalleryThumbnailsRepeater_GetData() // hämtar ut alla miniatyrer för att sen visas 
        {
            return Gallery.GetImageNames();
        }
    }
}
