using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Mixer;

namespace Remote_Computer_Control_System
{
  public class Mixer
    {
        #region Mute
        public void MuteAllDevices()
        {
            ChangeMute(true);
        }

        public void UnMuteAllDevices()
        {
            ChangeMute(false);
        }

        public bool GetState()
        {
            bool state = false;
            //Instantiate an Enumerator to find audio devices
            NAudio.CoreAudioApi.MMDeviceEnumerator MMDE = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            //Get all the devices, no matter what condition or status
            NAudio.CoreAudioApi.MMDeviceCollection DevCol = MMDE.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.All);
            //Loop through all devices
            foreach (NAudio.CoreAudioApi.MMDevice dev in DevCol)
            {
                try
                {
                    //Show us the human understandable name of the device
                    Console.WriteLine($"{dev.FriendlyName} : {dev.AudioEndpointVolume.Mute}");

                    //Mute it
                    state &= dev.AudioEndpointVolume.Mute;
                }
                catch (Exception ex)
                {
                    //Do something with exception when an audio endpoint could not be muted
                }
            }
            return state;
        }

        public bool ToggleState()
        {
            bool state = false;
            //Instantiate an Enumerator to find audio devices
            NAudio.CoreAudioApi.MMDeviceEnumerator MMDE = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            //Get all the devices, no matter what condition or status
            NAudio.CoreAudioApi.MMDeviceCollection DevCol = MMDE.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.All);
            //Loop through all devices
            foreach (NAudio.CoreAudioApi.MMDevice dev in DevCol)
            {
                try
                {
                    //Show us the human understandable name of the device
                    Console.WriteLine($"{dev.FriendlyName} : {dev.AudioEndpointVolume.Mute}");

                    //Mute it
                    dev.AudioEndpointVolume.Mute = ! dev.AudioEndpointVolume.Mute;
                }
                catch (Exception ex)
                {
                    //Do something with exception when an audio endpoint could not be muted
                    //Do something with exception when an audio endpoint could not be muted
                }
            }
            return state;
        }

        private void ChangeMute(bool state)
        {
            try
            {
                //Instantiate an Enumerator to find audio devices
                NAudio.CoreAudioApi.MMDeviceEnumerator MMDE = new NAudio.CoreAudioApi.MMDeviceEnumerator();
                //Get all the devices, no matter what condition or status
                NAudio.CoreAudioApi.MMDeviceCollection DevCol = MMDE.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.All);
                //Loop through all devices
                foreach (NAudio.CoreAudioApi.MMDevice dev in DevCol)
                {
                    try
                    {
                        //Show us the human understandable name of the device
                        System.Diagnostics.Debug.Print(dev.FriendlyName);
                        //Mute it
                        dev.AudioEndpointVolume.Mute =state;
                    }
                    catch (Exception ex)
                    {
                        //Do something with exception when an audio endpoint could not be muted
                    }
                }
            }
            catch (Exception ex)
            {
                //When something happend that prevent us to iterate through the devices
            }
            //foreach (var mixer in NAudio.Mixer.Mixer.Mixers)
            //{
            //    Console.WriteLine(mixer.Name);
            //    var dests = mixer.Destinations;
            //    foreach (var dest in dests)
            //    {
            //        Console.WriteLine("Destination Name: " + dest.Name);
            //        if (!dest.IsSource)
            //        {
            //            foreach (var control in dest.Controls)
            //            {
            //                Console.WriteLine("----CONTROL NAME: " + control.Name + " : " + control.IsBoolean);
            //                //Console.WriteLine( );
            //                if (control.ControlType == MixerControlType.Mute)
            //                {
            //                    BooleanMixerControl d = (BooleanMixerControl)control;
            //                    d.Value = state;
            //                    Console.WriteLine(d.Name + ":" + d.Value);
            //                    //mixer.GetDestination(dest.GetSource(0).)
            //                    //new NAudio.Mixer.BooleanMixerControl(control, 2, MixerFlags.Mixer, 1);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        #endregion
    }
}
