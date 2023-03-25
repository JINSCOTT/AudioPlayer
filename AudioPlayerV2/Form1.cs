using Microsoft.VisualBasic.Devices;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Xml.Linq;

namespace AudioPlayerV2
{
    public partial class Form1 : Form
    {


        MMDeviceEnumerator Enumerator = new MMDeviceEnumerator();
        WasapiOut? OutputDevice;
        AudioFileReader? audioFile;
        string AudioFileName = "";
        private System.Timers.Timer? SlideTimer;
        bool IsPlaying = false;
        Equalizer? equalizer;
        // Equalizer settings
        EqualizerBand[] bands = new EqualizerBand[]
                   {
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 32, Gain = 0},
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 64, Gain = 0},
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 125, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 250, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 500, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 1000, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 2000, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 4000, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 8000, Gain = 0 },
                        new EqualizerBand { Bandwidth = 0.8f, Frequency = 16000, Gain = 0 }
                   };

        #region FormFunction
        public Form1()
        {
            InitializeComponent();

        }
        
        /// <summary>
        /// Fill in audio output devices and get ready to listen for device status changes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Fill in all active audio output
            MMDeviceCollection DevCol = Enumerator.EnumerateAudioEndPoints(DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active);
            Debug.WriteLine("No. device: {0}", DevCol.Count);
            foreach (MMDevice device in DevCol)
            {
                Debug.WriteLine(device.FriendlyName);
                OutputDeviceSelectBox.Invoke((MethodInvoker)delegate
                {
                    OutputDeviceSelectBox.Items.Add(device.FriendlyName);
                });
            }
            if (OutputDeviceSelectBox.Items.Count > 0) OutputDeviceSelectBox.SelectedIndex = 0;

            // Listen to device changes
            Enumerator.RegisterEndpointNotificationCallback(new NotificationClient(OutputDeviceSelectBox));

            //Volume bar control
            Volumebar.Scroll += (s, a) =>
            {
                if (OutputDevice != null)
                {
                    OutputDevice.Volume = Volumebar.Value / 100f;
                }

            };
        }
        #endregion FormFunction
        #region FileSelect
        /// <summary>
        /// Select File button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select audio file";
            fileDialog.FileName = "";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic); //Directory of MyMusic 
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileNameBox.Text = fileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// If a new audio file is selected, pause.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (IsPlaying == true)
            {
                IsPlaying = false;
                StopTimer();
                if(OutputDevice!=null)OutputDevice.Pause();
            }
        }
        #endregion FileSelect
        /// <summary>
        /// Pause Playing when selected output changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputDeviceSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPlaying == true)
            {
                IsPlaying = false;
                StopTimer();
                if (OutputDevice != null) OutputDevice.Pause();
            }
        }

        #region PlayAndPause
        /// <summary>
        /// Event to deal with output device becomes unplugged during playing
        /// </summary>
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            IsPlaying = false;
            StopTimer();
            if (OutputDeviceSelectBox.SelectedItem == null) OutputDeviceSelectBox.SelectedIndex = 0;
        }
        
        /// <summary>
        /// Play button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (AudioFileName == FileNameBox.Text && IsPlaying) return; // Play button clicked repeatedly
            //new audio file
            if (AudioFileName != FileNameBox.Text) 
            {

                if (audioFile != null) audioFile.Dispose();
                try
                {
                    audioFile = new AudioFileReader(FileNameBox.Text); // Open audio file
                                                                      
                }
                catch
                {
                    string message = "Invalid audio file selected!";
                    string title = "ERROR";
                    MessageBox.Show(message, title);
                    return;
                }
                SetProgressBar();
            }

            AudioFileName = FileNameBox.Text;
            Enumerator = new MMDeviceEnumerator();
            // Find our selected device by name
            MMDevice? mMDevice = null;
            foreach (MMDevice device in Enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                if (device.FriendlyName == OutputDeviceSelectBox.SelectedItem.ToString())
                {
                    mMDevice = device;
                }
            }
            Enumerator.Dispose();
            if (mMDevice != null) OutputDevice = new WasapiOut(mMDevice, AudioClientShareMode.Shared, false, 50);
            // Equalizer
            if (audioFile != null) equalizer = new Equalizer(audioFile, bands);
            if (OutputDevice == null)
            {
                string message = "Can't open output device";
                string title = "ERROR";
                MessageBox.Show(message, title);
                return;
            }
            OutputDevice.Init(equalizer);
            //Volume
            OutputDevice.Volume = Volumebar.Value / 100f;
            //Start Playing
            IsPlaying = true;
            OutputDevice.PlaybackStopped += OnPlaybackStopped!;
            SetTimer();
            OutputDevice.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (IsPlaying == false) return;
            else if (OutputDevice!.PlaybackState == PlaybackState.Playing)
            {
                IsPlaying = false;
                OutputDevice.Pause();
            }
            StopTimer();
        }
        #endregion PlayAndPause
        #region EqualizerScroll
        private void EQ1_Scroll(object sender, EventArgs e)
        {
            bands[0].Gain = EQ1.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ2_Scroll(object sender, EventArgs e)
        {
            bands[1].Gain = EQ2.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ3_Scroll(object sender, EventArgs e)
        {
            bands[2].Gain = EQ3.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ4_Scroll(object sender, EventArgs e)
        {
            bands[3].Gain = EQ4.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ5_Scroll(object sender, EventArgs e)
        {
            bands[4].Gain = EQ5.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ6_Scroll(object sender, EventArgs e)
        {
            bands[5].Gain = EQ6.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ7_Scroll(object sender, EventArgs e)
        {
            bands[6].Gain = EQ7.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ8_Scroll(object sender, EventArgs e)
        {
            bands[7].Gain = EQ8.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ9_Scroll(object sender, EventArgs e)
        {
            bands[8].Gain = EQ9.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        private void EQ10_Scroll(object sender, EventArgs e)
        {
            bands[9].Gain = EQ10.Value;
            if (equalizer != null)
            {
                equalizer?.Update();
            }
        }
        #endregion EqualizerScroll
        #region ProgressBarControl
        /// <summary>
        /// Timer to update progress bar
        /// </summary>
        private void SetTimer()
        {
            SlideTimer = new System.Timers.Timer(1000);
            SlideTimer.Elapsed += ProgressBarTick;
            SlideTimer.AutoReset = true;
            SlideTimer.Enabled = true;
        }
        /// <summary>
        /// Delete timer.
        /// </summary>
        private void StopTimer()
        {
            if (SlideTimer != null)
            {
                
                    SlideTimer.Elapsed -= ProgressBarTick;
                
                
                SlideTimer.Dispose();
                SlideTimer = null;
            }
        }
        /// <summary>
        /// Pause playing when progress bar is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsPlaying)
            {
                if (SlideTimer != null)SlideTimer.Stop();
                if(OutputDevice!=null)OutputDevice.Pause();
            }
        }
        /// <summary>
        /// Continue playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (audioFile != null)
            {

                double ms = 0;
                ms = ProgressBar.Value;
                audioFile.CurrentTime = TimeSpan.FromSeconds(ms);
                if (IsPlaying)
                {
                    Thread.Sleep(100);
                    OutputDevice!.Play();
                    SlideTimer!.Start();
                }


            }
            else ProgressBar.Value = 0;
        }
        /// <summary>
        /// Event to update progress bar
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void ProgressBarTick(Object? source, ElapsedEventArgs e)
        {

            if (OutputDevice != null)
            {
                if (OutputDevice.PlaybackState != PlaybackState.Stopped)
                {
                    if (audioFile != null)
                    {
                        ProgressBar.Invoke((MethodInvoker)delegate
                        {
                            if (ProgressBar.Maximum < audioFile.CurrentTime.TotalSeconds)
                            {
                                ProgressBar.Value = ProgressBar.Maximum;
                            }
                            else ProgressBar.Value = (int)audioFile.CurrentTime.TotalSeconds;
                        });

                    }
                }
            }

        }
        /// <summary>
        /// Preset the progress bar
        /// </summary>
        private void SetProgressBar()
        {
            ProgressBar.Maximum = (int)audioFile!.TotalTime.TotalSeconds;
            // Set the trackbar with total seconds of the audiofile
            ProgressBar.Value = 0;
        }
        #endregion ProgressBarControl
    }

}