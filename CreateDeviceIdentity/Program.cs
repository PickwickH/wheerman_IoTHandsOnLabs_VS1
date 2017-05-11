using System;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDeviceIdentity
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=whpickwick.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=qi2W6PghBWqVMBiHegYSQBlYCrvFzVCOWF+KiKj9Yos=";
        
        private static async Task AddDeviceAsync()
        {
            string deviceId = "myFirstDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
            /// <summary>
            /// Console.WriteLine("Generated device key Copy: {0}", registryManager.AddDeviceAsync(new Device(deviceId));
            /// <returns></returns>
        }
        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }
        
    }
}
