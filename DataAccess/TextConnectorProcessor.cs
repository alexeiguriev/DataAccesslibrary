using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesslibrary.Models;

// * Load the text file
// * Convert the list to tect file
// Finde the max ID
// Add the new record with the new ID (max + 1)
// Convert the prizes to the list<string>
// Save the list<string> to the text file
namespace DataAccesslibrary.DataAccess
{
    public static class TextConnectorProcessor
    { 

        static string filePath = "d:\\2_cSharp\\intership\\USER_ManagerPrj";
        public static string FullFilePath(this string fileName)
        {
            return $"{filePath}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (false == File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }
        public static List<UserModel> ConvertToUserModel(this List<string> lines)
        {
            List<UserModel> output = new List<UserModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                UserModel p = new UserModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.Password = cols[4];
                output.Add(p);
            }
            return output;
        }

        public static void SaveToPersonFile(this List<UserModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (UserModel p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName},{ p.EmailAddress },{ p.Password }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
