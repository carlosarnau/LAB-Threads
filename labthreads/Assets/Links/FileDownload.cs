using System.Net;

namespace Server
{
    public class DownloadFile
    {
        public static void DownloadFileFromUrl(string url, string localFilePath)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(url, localFilePath);
        }
        
    }
   
}