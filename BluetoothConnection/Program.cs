using Bluetooth.GATT.Events;
using System;
using System.Threading;

namespace BluetoothConnection
{

    class Program
    {
        static void Main(string[] args)
        {
            var deviceSelector = Bluetooth.GATT.Schema.DeviceSelector.BluetoothLe;

            var watcher = new Bluetooth.GATT.BLEDeviceWatcher(deviceSelector);

            watcher.DeviceEnumerationCompleted += delegate (object o, object e)
            {
                Console.WriteLine("Completed!");
            };

            watcher.DeviceUpdated += delegate (object o, DeviceUpdatedEventArgs e)
            {
                var device = e.Device;

                var properties = device.Properties;

                foreach (var item in properties)
                {
                    var key = item.Key;
                    var val = item.Value;

                    Console.WriteLine($"{key}: {val}");
                }

                Console.WriteLine(new string('-', 10));
            };
            
            watcher.Start();

            Console.WriteLine(watcher.Running);

            Thread.Sleep(TimeSpan.FromMinutes(3));


            watcher.Dispose();



            

        }
    }
}
