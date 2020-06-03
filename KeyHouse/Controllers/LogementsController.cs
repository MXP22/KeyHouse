using KeyHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeyHouse.Controllers
{
    public class LogementsController : Controller
    {
        private KeyHouseEntities db = new KeyHouseEntities();

        // GET: Logements
        public ActionResult Create()
        {
            List<String> TypeLogement = new List<string>() { "Villa", "Appartement", "Studio", "Maison", "Terrain", "Parking" };

            ViewBag.List = TypeLogement;

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<HttpPostedFileBase> files, LogModel logModel)
        {
            Logements logementsAdd = new Logements();
            List<ImageLogement> imageLogementAdd = new List<ImageLogement>();


            List<String> TypeLogement = new List<string>() { "Villa", "Appartement", "Studio", "Maison", "Terrain", "Parking" };

            ViewBag.List = TypeLogement;


            int Idlog = logementsAdd.idLogement;
            logementsAdd.TitreLogemenet = logModel.Titre;
            logementsAdd.DescriptionLogement = logModel.Description;
            logementsAdd.Nbrchambre = logModel.Nomberdepieces;
            logementsAdd.surface = logModel.Surface;
            logementsAdd.Prix = logModel.prix;
            logementsAdd.Adresse = logModel.Adresse;
            logementsAdd.Typelogement = logModel.typelogement;
            //logementsAdd.villes.IDville = 1;



            db.Logements.Add(logementsAdd);

            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (var file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/App_Data/ImageFile/"), InputFileName);
                        //Save file to server folder  

                        file.SaveAs(ServerSavePath);

                        imageLogementAdd.Add(new ImageLogement { NomImage = InputFileName, PathImage = ServerSavePath, idLog = Idlog });

                       
                    }


                }
                for (int i = 0; i < imageLogementAdd.Count; i++)
                {
                    db.ImageLogement.Add(imageLogementAdd[i]);
                }


            }
            db.SaveChanges();

             var script = @"alert(""Email sent successfully"");";
        
          
            return View(JavaScript(script));

        }

        public ActionResult ShowLogement()
        {

            var listLogement = db.Logements.Include(d => d.ImageLogement).ToList();




            return View(listLogement);

        }











    }
}
