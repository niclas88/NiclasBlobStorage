using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole1.Controllers
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

        BlobStorageService blobStorageService = new BlobStorageService();

        public ActionResult UploadImage()
        {
            CloudBlobContainer blobContainer = blobStorageService.GetImageBlobContainer();
            List<string> blobs = new List<string>();

            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return View(blobs);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image)
        {
            if (image.ContentLength > 0)
            {
                CloudBlobContainer blobContainer = blobStorageService.GetImageBlobContainer();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(image.FileName);
                blob.UploadFromStream(image.InputStream);
            }
            return RedirectToAction("UploadImage");
        }

        [HttpPost]
        public string DeleteImage(string name)
        {
            Uri uri = new Uri(name);
            string fileName = System.IO.Path.GetFileName(uri.LocalPath);

            CloudBlobContainer blobContainer = blobStorageService.GetImageBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);

            blob.Delete();

            return "Image Deleted";
        }

        public ActionResult UploadVideo()
        {
            CloudBlobContainer blobContainer = blobStorageService.GetVideoBlobContainer();
            List<string> blobs = new List<string>();

            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return View(blobs);
        }

        [HttpPost]
        public ActionResult UploadVideo(HttpPostedFileBase video)
        {
            if (video.ContentLength > 0)
            {
                CloudBlobContainer blobContainer = blobStorageService.GetVideoBlobContainer();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(video.FileName);
                blob.UploadFromStream(video.InputStream);
            }
            return RedirectToAction("UploadVideo");
        }

        [HttpPost]
        public string DeleteVideo(string name)
        {
            Uri uri = new Uri(name);
            string fileName = System.IO.Path.GetFileName(uri.LocalPath);

            CloudBlobContainer blobContainer = blobStorageService.GetVideoBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);

            blob.Delete();

            return "Video Deleted";
        }

        public ActionResult UploadFile()
        {
            CloudBlobContainer blobContainer = blobStorageService.GetFileBlobContainer();
            List<string> blobs = new List<string>();

            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return View(blobs);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                CloudBlobContainer blobContainer = blobStorageService.GetFileBlobContainer();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(file.FileName);
                blob.UploadFromStream(file.InputStream);
            }
            return RedirectToAction("UploadFile");
        }

        [HttpPost]
        public string DeleteFile(string name)
        {
            Uri uri = new Uri(name);
            string fileName = System.IO.Path.GetFileName(uri.LocalPath);

            CloudBlobContainer blobContainer = blobStorageService.GetFileBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);

            blob.Delete();

            return "File Deleted";
        }
    }
}