using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CommonMethods
{
    public class FTPreload
    {
        /// <summary>
        /// 大文件卡死
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="serverUri"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static bool RestartDownloadFromServer(string fileName, Uri serverUri, long offset)
        {
            // The serverUri parameter should use the ftp:// scheme.
            // It identifies the server file that is to be downloaded
            // Example: ftp://contoso.com/someFile.txt.

            // The fileName parameter identifies the local file.
            //The serverUri parameter identifies the remote file.
            // The offset parameter specifies where in the server file to start reading data.

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Credentials = new NetworkCredential("admin", "123456");

            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.ContentOffset = offset;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
                Console.WriteLine(e.Message);
                return false;
            }
            // Get the data stream from the response.
            Stream newFile = response.GetResponseStream();
            // Use a StreamReader to simplify reading the response data.
            StreamReader reader = new StreamReader(newFile);
            string newFileData = reader.ReadToEnd();
            // Append the response data to the local file
            // using a StreamWriter.
            StreamWriter writer = File.AppendText(fileName);
            writer.Write(newFileData);
            // Display the status description.

            // Cleanup.
            writer.Close();
            reader.Close();
            response.Close();
            Console.WriteLine("Download restart - status: {0}", response.StatusDescription);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="serverUri"></param>
        /// <param name="offset"></param>
        /// <param name="user">FTP用户名</param>
        /// <param name="password">FTP密码</param>
        /// <returns></returns>
        public static bool RestartDownloadFromServer(string fileName, Uri serverUri, long offset, string user, string password)
        {
            // The serverUri parameter should use the ftp:// scheme.
            // It identifies the server file that is to be downloaded
            // Example: ftp://contoso.com/someFile.txt.

            // The fileName parameter identifies the local file.
            //The serverUri parameter identifies the remote file.
            // The offset parameter specifies where in the server file to start reading data.

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            FileStream outputStream = new FileStream(fileName, FileMode.Append);
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Credentials = new NetworkCredential(user, password);

            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.ContentOffset = offset;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
                Console.WriteLine(e.Message);
                return false;
            }
            // Get the data stream from the response.
            Stream ftpStream = response.GetResponseStream();
            int bufferSize = 2048;
            int readCount;
            byte[] buffer = new byte[bufferSize];
            readCount = ftpStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                outputStream.Write(buffer, 0, readCount);

                readCount = ftpStream.Read(buffer, 0, bufferSize);
            }

            // Cleanup.
            outputStream.Close();
            ftpStream.Close();
            response.Close();
            Console.WriteLine("Download restart - status: {0}", response.StatusDescription);
            return true;
        }



        /// <summary>
        /// 从ftp服务器下载单个文件的功能
        /// </summary>
        /// <param name="baseUrl">ftp服务器基地址+端口</param>
        /// <param name="ftpfilepath">ftp下载的地址</param>
        /// <param name="filePath">存放到本地的路径</param>
        /// <param name="fileName">保存的文件名称</param>
        /// <returns></returns>
        public static bool Download(string baseUrl, string ftpfilepath, string filePath, string fileName, string user, string password)
        {
            Stream ftpStream = null;
            FtpWebResponse response = null;
            FileStream outputStream = null;
            try
            {
                string newFileName = filePath + fileName;
                ftpfilepath = ftpfilepath.Replace("\\", "/");
                string url = baseUrl + ftpfilepath + fileName;
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFtp.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFtp.Credentials = new NetworkCredential(user, password);
                response = (FtpWebResponse)reqFtp.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength; //记录一下下载文件的大小
                //为了避免出错保证先删除本地已存在文件
                if (File.Exists(newFileName))
                {
                    File.Delete(newFileName);
                }
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                outputStream = new FileStream(newFileName, FileMode.Create, FileAccess.ReadWrite);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }

        }
    }
}
