﻿using System;
using System.IO;

namespace UsersApp.Session
{
    class UserProfile
    {
        public String username { get { return Path.GetFileName(path); } }
        public String path { get; set; }
        public String filepath { get { return path + ".xml"; } }

        public UserProfile(String username)
        {
            this.path = username.Replace(".xml", "");
        }
    }
}
