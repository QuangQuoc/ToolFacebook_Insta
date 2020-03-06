﻿using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateAccountsProject.Services
{
    public class DeviceVariablesService
    {
        public static int MaxThread { get; set; }
        public static Host MyHost { get; set; }
        public static string MyHostName { get; set; }
        public static int ThreadRunning { get; set; }
        public static List<Thread> ThreadsRunning { get; set; }
        public static bool CreateBotLive { get; set; }
        public static int TimeCreateDevice { get; set; }
        public static int TimeRunDevice { get; set; }
        public static int TimeRestartDevice { get; set; }
        public static int TimeConfigDevice { get; set; }
        public static int  TimeInstallApp { get; set; }
        public static LDProperty ConfigDevice { get; set; }
        public static List<string> DeviceIpsRunning { get; set; }
        public static string ApkPath { get; set; }
        public static string ApkBrowserName { get; set; }
        public static string ApkFacebookName { get; set; }
        public static string LdDirectory { get; set; }
        public static string BrowserName { get; set; }
        public static string PackageNameFbName { get; set; }
        public static string Password { get; set; }
        public static bool UseClipboard { get; set; }
        // Server 2FA, Avatar
        public static string GetAvatarUrl { get; set; }
<<<<<<< HEAD
        public static string HostServerSuport { get; set; }
=======
        public static string ServerHostName { get; set; }
        public static List<Thread> ThreadsRunning { get; set; }
>>>>>>> Feature-Management

        public static void Initial()
        {
            CreateBotLive = true;
            MyHostName = "QuangQuoc_01";
            ThreadRunning = 0;
            ThreadsRunning = new List<Thread>();
            TimeCreateDevice = 30;
            TimeConfigDevice = 50;
            TimeRunDevice = 240;
            TimeRestartDevice = 100;
            TimeInstallApp = 30;
            ConfigDevice = new LDProperty() { Cpu = "1", Memory = "1024", Imei = "", Resolution = "540,960,240" };
<<<<<<< HEAD
            //ApkPath = @"E:\02. Cong viec\Share_Quoc_Sang\DataKhongShare\02. File APK\FileAPK\";
=======
>>>>>>> Feature-Management
            ApkPath = Environment.CurrentDirectory + @"\APK\";
        
            ApkBrowserName = "Via0";
            ApkFacebookName = "NameFacebook.apk";
            DeviceIpsRunning = new List<string>();
            LdDirectory = @"C:\LDPlayer"; 
            BrowserName = "mark.via.gp0";
            PackageNameFbName = "com.example.namefacebook";
            Password = "quocsang199698";
<<<<<<< HEAD
            UseClipboard = false;
<<<<<<< HEAD
            GetAvatarUrl = HostServerSuport + "/avatars";
            HostServerSuport = "http://quocsang.ddns.net:3000";
=======
            GetAvatarUrl = ServerHostName + "/avatars";
            ServerHostName = "http://quocsang.ddns.net:3000";
>>>>>>> Feature-Management
=======
            UseClipboard = false;           
            HostServerSuport = "http://quocsang.ddns.net:3000";
            GetAvatarUrl = HostServerSuport + "/avatars";
>>>>>>> Feature-CreateFileSetup
        }

        public static void AddmaxThread(int mt)
        {
            MaxThread = mt;
        }
    }
}
