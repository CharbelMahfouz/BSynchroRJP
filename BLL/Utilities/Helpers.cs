using BLL.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities
{
    public static class Helpers
    {
        private static Random random = new Random();
        public static ResponseModel CreateResponseModel(int result, string message, dynamic data)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                Result = result,
                Message = message,
                Data = data
            };
            return responseModel;
        }
        public static async Task<bool> SendEmailAsync(string toEmail, string subject, string content)
        {
            var client = new RestClient("https://api.sendinblue.com/v3/smtp/email");
            var request = new RestRequest(Method.POST);
            request.AddHeader("api-key", "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");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("undefined",
                "{\"tags\":[\"Tileo\"],\"sender\":{\"email\":\"" +
                "YallaJeye@gmail.com" + "\"},\"to\":[{\"email\":\"" + toEmail + "\",\"name\":\"" +
                toEmail + "\"}],\"cc\":[{\"email\":\"YallaJeye@gmail.com\",\"name\":\"Yalla Jeye\"}," +
                "{\"email\":\"YallaJeye@gmail.com \",\"name\":\"Yalla Jeye\"}],\"htmlContent\":\"" +
                content + "\",\"textContent\":\"" + content + "\",\"replyTo\":{\"email\":\"" +
                toEmail + "\"},\"subject\":\"" +
                subject + "\"}", ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }

        public static string Generate_otp()
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random objran = new Random();
            for (int i = 0; i < 4; i++)
            {
                //It will not allow Repetation of Characters
                int pos = objran.Next(1, charArr.Length);
                if (!strrandom.Contains(charArr.GetValue(pos).ToString())) strrandom += charArr.GetValue(pos);
                else i--;
            }
            return strrandom;
        }


        public static string RandomStringNoCharacters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //public static async Task<string> SaveFile(string path, IFormFile file)
        //{
        //    var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();

        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, NewFileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    return filePath;
        //}

        public static async Task<string> SaveFileReturnPath(string path, IFormFile file)
        {
            var NewFileName = Guid.NewGuid().ToString() + file.FileName.ToString();
            var dir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(path, NewFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            path = filePath.Replace("wwwroot", "").Replace("\\", "/");
            //path = filePath.Replace("\\", "/");

            return path;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        //public static void DeleteFile(string fileName, string path, IWebHostEnvironment hostEnvironment)
        //{
        //    var filePath = Path.Combine(hostEnvironment.ContentRootPath, path, fileName);
        //    if (File.Exists(filePath))
        //        File.Delete(filePath);
        //}
    }
}
