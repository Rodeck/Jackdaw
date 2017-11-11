using DataMiner.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DataMiner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetImages()
        {
            return View(new ImageMine());
        }

        [HttpPost]
        public ActionResult MineImages(string basePath, string extension, int start, int stop, string localPath)
        {

            ImageMineUrlData urlData = new ImageMineUrlData() { BasePath = basePath, Extension = extension, LocalPath = localPath, Start = start, Stop = stop };

           
            return View("GetImages", GetData(urlData));
        }

        public ImageMine GetData(ImageMineUrlData urlData)
        {
            ImageMine model = new ImageMine();
            int exceptionCount = 0;
            int maxExceptionCount = 2;
            string deliminator = "<//br>";

            try
            {
                for (int i = urlData.Start; i < urlData.Stop; i++)
                {
                    try
                    {
                        HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(urlData.BasePath + "//" + i + "." + urlData.Extension);
                        webReq.CookieContainer = new CookieContainer();
                        webReq.Method = "GET";
                        using (WebResponse response = webReq.GetResponse())
                        {
                            Image webImage = Image.FromStream(response.GetResponseStream()); // Error

                            webImage.Save(urlData.LocalPath + "//" + i + "." + urlData.Extension);
                        }
                    }
                    catch(Exception e)
                    {
                        exceptionCount++;
                        model.Message += deliminator + e.Message;

                        if (exceptionCount >= maxExceptionCount)
                        {                           
                            return model;
                        }
                    }

                                       
                }
            }
            catch(Exception e)
            {
                model.Message = "Completed with exception." + e.Message;
                return model;
            }

            model.Message = "Success!";
            return model;

        }
    }

    

    public class ImageMineUrlData
    {
        public string BasePath { get; set; }
        public string Extension { get; set; }
        public int Start { get; set; }
        public int Stop { get; set; }
        public string LocalPath { get; set; }
    }
}