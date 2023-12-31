﻿using DAL.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
//using DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities
{
    public static class Tools
    {
        //public static async Task<string> SaveImage(this IFormFile formFile, string folderName)
        //{
        //    string path = Path.Combine("wwwroot", "Images", folderName, Guid.NewGuid().ToString() + formFile.FileName);
        //    using (FileStream fs = new FileStream(path, FileMode.Create))
        //    {
        //        await formFile.CopyToAsync(fs);

        //    }
        //    path = path.Replace("wwwroot", "");
        //    return path;
        //}

        public static double CalculateDistance(double userLon, double userLat, double destLon, double destLat)
        {
            var d1 = userLat * (Math.PI / 180.0);
            var num1 = userLon * (Math.PI / 180.0);
            var d2 = destLat * (Math.PI / 180.0);
            var num2 = destLon * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
        //public static async Task<List<string>> SaveImages(List<IFormFile> formFiles, string folderName)
        //{
        //    List<string> result = new List<string>();
        //    foreach (IFormFile form in formFiles)
        //    {
        //        string path = await form.SaveImage(folderName);
        //        result.Add(path);
        //    }
        //    return result;
        //}



        public static List<Claim> GenerateClaims(ApplicationUser res, IList<string> roles)
        {
            var claims = new List<Claim>()
                {
                //new Claim(JwtRegisteredClaimNames.Email , res.Email),
                new Claim(ClaimTypes.Name , res.UserName),
                //new Claim("PID"  ,profileId.ToString()),
                //new Claim("BuddyID",buddy.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, res.Id),
                };
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public static List<Claim> GenerateClaimsMVC(ApplicationUser res, IList<string> roles)
        {
            //string FullName = buddy.FirstName+ " "+ buddy.LastName;
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, res.Email),
            //new Claim(ClaimTypes.Role, "Administrator"),
            new Claim(ClaimTypes.NameIdentifier, res.Id),


        };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }





        public static bool Between(double? number, double? min, double? max)
        {
            return number >= min && number <= max;
        }

        //public static async Task<string> SaveVideo(this IFormFile formFile, string folderName)
        //{
        //    string path = Path.Combine("wwwroot", "Videos", folderName, Guid.NewGuid().ToString() + ".mp4");
        //    using (FileStream fs = new FileStream(path, FileMode.Create))
        //    {
        //        await formFile.CopyToAsync(fs);
        //    }
        //    return path;
        //}


        //public static async Task<List<string>> SaveVideos(List<IFormFile> formFiles, string folderName)
        //{
        //    List<string> result = new List<string>();
        //    foreach (IFormFile form in formFiles)
        //    {
        //        string path = await form.SaveVideo(folderName);
        //        result.Add(path);
        //    }
        //    return result;
        //}

        //public static async Task<bool> SendEmailAsync(string toEmail, string subject, string content)
        //{
        //    var client = new RestClient("https://api.sendinblue.com/v3/smtp/email");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("api-key", "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");
        //    request.AddHeader("content-type", "application/json");
        //    request.AddHeader("Accept", "application/json");
        //    request.AddParameter("undefined",
        //        "{\"tags\":[\"Hooka Times\"],\"sender\":{\"email\":\"" +
        //        "info@arenasystem.co" + "\"},\"to\":[{\"email\":\"" + toEmail + "\",\"name\":\"" +
        //        toEmail + "\"}],\"cc\":[{\"email\":\"info@arenasystem.co\",\"name\":\"HookaTimes\"}," +
        //        "{\"email\":\"info@arenasystem.co \",\"name\":\"HookaTimes\"}],\"htmlContent\":\"" +
        //        content + "\",\"textContent\":\"" + "hiiii" + "\",\"replyTo\":{\"email\":\"" +
        //        toEmail + "\"},\"subject\":\"" +
        //        subject + "\"}", ParameterType.RequestBody);

        //    IRestResponse response = await client.ExecuteAsync(request);
        //    return response.IsSuccessful;
        //}



        public static string GetClaimValue(HttpContext httpContext, string valueType)
        {
            if (string.IsNullOrEmpty(valueType)) return null;

            var identity = httpContext.User.Identity as ClaimsIdentity;
            if (identity.IsAuthenticated)
            {
                var valueObj = identity == null ? null : identity.Claims.FirstOrDefault(x => x.Type == valueType);
                return valueObj == null ? null : valueObj.Value;
            }
            return null;
        }

        public static string ImageTypes = ".jpg,.bmp,.PNG,.EPS,.gif,.TIFF,.tif,.jfif";

    }
}
