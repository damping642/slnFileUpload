using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjFileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {
            //上傳圖檔
            string fileName = "";
            //檔案上傳
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                { 
                    fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine
                    (Server.MapPath("~/Photos"), fileName);
                    photo.SaveAs(path);
                }
            }
            return RedirectToAction("ShowPhotos");
        }
        //顯示所有圖檔
        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/photos"));
            FileInfo[] fInfo = dir.GetFiles();
            int n = 0;
            foreach (FileInfo result in fInfo)
            {
                n++;
                show += "<a href='../Photos/" + result.Name +
                    "' target='_blank'><img src='../Photos/" + result.Name +
                    "' width='90' height='60' border='0'></a> ";
                if (n%4 == 0) //顯示4個圖後換行
                {
                    show += "<p>";
                }   
            }
            show += "<p><a href='Create'>返回</a></p>";
            return show;
        }
    }
}