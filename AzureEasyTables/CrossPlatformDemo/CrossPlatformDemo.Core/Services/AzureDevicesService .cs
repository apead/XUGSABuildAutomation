using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using CrossPlatformDemo.Core.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace CrossPlatformDemo.Core.Services
{
    public class AzureDevicesService
    {
        public static string Path { get; set; } = "devices.db";

        private IMobileServiceSyncTable<Device> _deviceTable;


        public MobileServiceClient DevicesMobileService { get; set; }



        public async Task InitializeAsync()
        {
            DevicesMobileService = new MobileServiceClient("https://XamarinTechSummitDemo.azurewebsites.net");

           try
            {


                var store = new MobileServiceSQLiteStore(Path);
                store.DefineTable<Device>();
                await DevicesMobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

                _deviceTable = DevicesMobileService.GetSyncTable<Device>();

            }
            catch (Exception ex)
            {
                // Handle exception

                Debug.WriteLine(ex.Message);
            }

        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            return await _deviceTable.OrderBy(c => c.DeviceName).ToListAsync();
        }

        public async Task SynchronizeAsync()
        {
            try
            {
                await _deviceTable.PullAsync("allDevices", _deviceTable.CreateQuery());
                await DevicesMobileService.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
