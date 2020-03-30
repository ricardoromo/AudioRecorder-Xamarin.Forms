using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioRecorder.DependencyServices;
using Xamarin.Forms;

namespace AudioRecorder
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool isRecording = false;

        public IAudioRecorder AudioRecorder { get; set; }
        public IAudioPlayer AudioPlayer { get; set; }

        public MainPage()
        {

            AudioRecorder = DependencyService.Get<IAudioRecorder>();
            AudioPlayer = DependencyService.Get<IAudioPlayer>();

            AudioPlayer.AudioFilePath = Path.GetTempPath();
            AudioRecorder.AudioFilePath = Path.GetTempPath();

            InitializeComponent();
        }

        void StartRecording_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!isRecording)
            {
                string audioFileName = Guid.NewGuid().ToString();
                AudioRecorder.AudioFileName = audioFileName;
                AudioPlayer.AudioFileName = audioFileName;
                AudioRecorder.StartRecord();
                isRecording = true;
                recordingButton.Text = "Recording......";
            }
            else
            {
                AudioRecorder.StopRecord();
                isRecording = false;
                recordingButton.Text = "Start Recording";
            }
        }

        void PlayAudio_Clicked(System.Object sender, System.EventArgs e)
        {
            if (File.Exists(AudioRecorder.AudioFilePath + "/" + AudioRecorder.AudioFileName + ".wav"))
                AudioPlayer.PlayAudio();
            else
                DisplayAlert("Whooops!", "Record something first", "Ok");
        }
    }
}
