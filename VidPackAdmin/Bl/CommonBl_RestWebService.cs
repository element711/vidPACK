﻿using Microsoft.ServiceBus.Notifications;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VidPackAdmin.ViewModel;
using VidPackModel;

namespace VidPackAdmin.Bl
{
    class CommonBl_RestWebService : ICommonBl
    {
        public static NotificationHubClient _NotificationHubClient;
        public Uri _webServiceUri; 

        public CommonBl_RestWebService()
        {
            App.LocalConfiguration = ReadLocalConfiguration();
            string notificationHubConnectionString = App.LocalConfiguration.NotificationHub_ConnectionString;
            string notificationHubPath = App.LocalConfiguration.NotificationHub_HubPath; 
            _webServiceUri = new Uri(App.LocalConfiguration.BackendUrl);

            _NotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(notificationHubConnectionString, notificationHubPath);
        }

        public async Task<bool> SendToastNotificationAsync(string toast, string xmlTemplate, string notificationTag)
        {
            string payLoad = String.Format(xmlTemplate, toast);
            await _NotificationHubClient.SendWindowsNativeNotificationAsync(payLoad, notificationTag);

            return true;
        }

        public async Task<bool> SendTileNotificationAsync(TileNotification tileUpdate, string xmlTemplate, string notificationTag)
        {
            string payLoad = String.Format(xmlTemplate, tileUpdate.Headline, tileUpdate.Line1, tileUpdate.Line2, tileUpdate.Line3);
            await _NotificationHubClient.SendWindowsNativeNotificationAsync(payLoad, notificationTag);

            return true;
        }


        public async Task<List<NotificationInfo>> LoadNotificationTagAsync()
        {
            string serviceEndpoint = "notification";
            List<NotificationInfo> returnValue = new List<NotificationInfo>();

            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = new Uri(string.Format("{0}{1}", _webServiceUri, serviceEndpoint));
                string jsonResult = await httpClient.GetStringAsync(uri);
                returnValue = Deserialize<List<NotificationInfo>>(jsonResult);
            }

            return returnValue;

        }

        public LocalConfigurationInfo ReadLocalConfiguration()
        {
            LocalConfigurationInfo localConfiguration = new LocalConfigurationInfo()
            {
                BackendUrl = ConfigurationManager.AppSettings.Get("BackendUrl"),
                NotificationHub_ConnectionString = ConfigurationManager.AppSettings.Get("NotificationHub_ConnectionString"),
                NotificationHub_HubPath = ConfigurationManager.AppSettings.Get("NotificationHub_HubPath"),
                MediaServices_AccountKey = ConfigurationManager.AppSettings.Get("MediaServices_AccountKey"),
                MediaServices_AccountName = ConfigurationManager.AppSettings.Get("MediaServices_AccountName"),
            };
            return localConfiguration;
        }

        public void SaveLocalConfiguration(LocalConfigurationInfo localConfiguration)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appSettingsSection = configuration.AppSettings;

            appSettingsSection.Settings.Remove("BackendUrl"); 
            appSettingsSection.Settings.Add("BackendUrl", localConfiguration.BackendUrl);
            appSettingsSection.Settings.Remove("NotificationHub_ConnectionString"); 
            appSettingsSection.Settings.Add("NotificationHub_ConnectionString", localConfiguration.NotificationHub_ConnectionString);
            appSettingsSection.Settings.Remove("NotificationHub_HubPath"); 
            appSettingsSection.Settings.Add("NotificationHub_HubPath", localConfiguration.NotificationHub_HubPath);

            appSettingsSection.Settings.Remove("MediaServices_AccountName");
            appSettingsSection.Settings.Add("MediaServices_AccountName", localConfiguration.MediaServices_AccountName);
            appSettingsSection.Settings.Remove("MediaServices_AccountKey");
            appSettingsSection.Settings.Add("MediaServices_AccountKey", localConfiguration.MediaServices_AccountKey);


            configuration.Save(ConfigurationSaveMode.Modified);
        }


        //********************************************************************************************
        //* JSON Helper
        //********************************************************************************************
        public T Deserialize<T>(string json)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(json);
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(memoryStream);
            }
        }

    }
}
