using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UsersApp.Model;
using UsersApp.Model.XML;

namespace UsersApp.Session
{
    class UserSession
    {
        private static readonly UserSession instance = new UserSession();
        public UserProfile currentUser { get; set; }
        private List<UserProfile> avaiableUsers;
        public readonly String DIRECTORY = "profiles";
        private UserSession()
        {
            CreateProfileDirIfNotExist();

            avaiableUsers = new List<UserProfile>();
            this.ReloadAvaiableUsers();
            CreateProfileIfNonExist();
        }

        private void CreateProfileIfNonExist()
        {
            if (avaiableUsers.Count < 1)
            {
                CreateUser("Administrator");
                this.ReloadAvaiableUsers();
                SelectUserByName("Administrator");
            }
            else
            {
                currentUser = avaiableUsers.First();
            }
        }

        private void CreateProfileDirIfNotExist()
        {
            if (!Directory.Exists(DIRECTORY))
            {
                Directory.CreateDirectory(DIRECTORY);
            }
        }

        public static UserSession GetInstance()
        {
            return instance;
        }

        public List<UserProfile> GetProfiles()
        {
            return new List<UserProfile>(avaiableUsers);
        }

        public void ReloadAvaiableUsers()
        {
            avaiableUsers.Clear();

            String[] filenames = Directory.GetFiles(DIRECTORY, "*.xml", SearchOption.TopDirectoryOnly);
            foreach(String name in filenames)
            {
                avaiableUsers.Add(new UserProfile(name));
            }
        }

        public void SelectUserByName(String username)
        {
            UserProfile selected = avaiableUsers.FirstOrDefault(item => item.username.Equals(username));
            if (selected != null)
            {
                currentUser = selected;
            }
        }

        public void CreateUser(String username)
        {
            PersonXML.WriteToFile(new List<Person>(), username + ".xml");
        }

        public void RemoveUser(String username)
        {

        }
    }
}
