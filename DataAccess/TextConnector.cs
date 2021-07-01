using DataAccesslibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public UserModel PutUser(UserModel oldVal, UserModel newVal)
        {
            throw new NotImplementedException();
        }

        public UserModel DeleteUser(UserModel model)
        {
            throw new NotImplementedException();
        }
        private const string PeopleFile = "UserModels.csv";

        public UserModel PostUser(UserModel model)
        {
            // Load the text file and Convert the list to tect file
            List<UserModel> person = PeopleFile.FullFilePath().LoadFile().ConvertToUserModel();

            // Finde the max ID
            int curentId = 1;

            if (person.Count > 0)
            {
                curentId = person.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = curentId;

            // Add the new record with new ID (max + 1)
            person.Add(model);

            // Convert the prizes to the list<string>
            // Save the list<string> to the text file
            person.SaveToPersonFile(PeopleFile);

            return model;
        }

        public List<UserModel> GetUser_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToUserModel();
        }

    }
}
