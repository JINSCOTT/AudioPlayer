using NAudio.CoreAudioApi.Interfaces;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace AudioPlayerV2
{
    /// <summary>
    /// Listens to the IMMNotificationClient event.
    /// Will be triggered on any Audio device changes. However this program only concerns outputs.
    /// </summary>
    class NotificationClient : NAudio.CoreAudioApi.Interfaces.IMMNotificationClient
    {

        public System.Windows.Forms.ComboBox _OutputSelectBox;

        public NotificationClient(System.Windows.Forms.ComboBox OutputBox)
        {

            _OutputSelectBox = OutputBox;
        }
        void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            // Start by finding device name
            MMDevice? ChangeDevice = null;
            MMDeviceEnumerator enumerator = new();

            foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.All))
            {
                if (device.ID == deviceId)
                {
                    ChangeDevice = device;
                    break;
                }
            }
            enumerator.Dispose();
            if (ChangeDevice == null) return;
            else if (ChangeDevice.DataFlow != DataFlow.Render) return;
            string DeviceName = ChangeDevice.FriendlyName;
            // Remove the device if it becomes inactive. Otherwise, add it.
            if (newState == DeviceState.Unplugged)
            {
                    _OutputSelectBox.Invoke((MethodInvoker)delegate
                    {
                        _OutputSelectBox.Items.Remove(DeviceName);
                    });              
            }
            else if (newState == DeviceState.NotPresent)
            {      
                    _OutputSelectBox.Invoke((MethodInvoker)delegate
                    {
                        _OutputSelectBox.Items.Remove(DeviceName);
                    });
               
            }
            else if (newState == DeviceState.Active)
            {
                    _OutputSelectBox.Invoke((MethodInvoker)delegate
                    {
                        _OutputSelectBox.Items.Add(DeviceName);
                    });
            }
            _OutputSelectBox.Invoke((MethodInvoker)delegate
            {
                if (_OutputSelectBox.Items.Count == 0)
                {
                    _OutputSelectBox.Text = "";
                    _OutputSelectBox.SelectedIndex = -1;
                }
            });
        }
        // Don't care
        void IMMNotificationClient.OnDeviceAdded(string PwstrDeviceId) { Debug.WriteLine("Device added {0}", PwstrDeviceId); }
        void IMMNotificationClient.OnDeviceRemoved(string deviceId) { Debug.WriteLine("Device removed {0}", deviceId); }
        void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId) { Debug.WriteLine("Device changed {0}, {1}, {2}", flow, role, defaultDeviceId); }
        void IMMNotificationClient.OnPropertyValueChanged(string PwstrDeviceId, PropertyKey key) { Debug.WriteLine("On Property value changed{0}, {1}", PwstrDeviceId, key); }

    }

}
