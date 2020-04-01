using System;
using Android.Media;
using AudioRecorder.DependencyServices;
using AudioRecorder.Droid.DependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(AudioRecorder_Android))]
namespace AudioRecorder.Droid.DependencyService
{
    public class AudioRecorder_Android : IAudioRecorder
    {
        public MediaRecorder Recorder { get; set; }
        public string AudioFileName { get; set; }
        public string AudioFilePath { get; set; }

        public AudioRecorder_Android()
        {
            Recorder = new MediaRecorder ();
        }

        public void StartRecord()
        {
            Recorder.SetAudioSource(AudioSource.Mic);
            Recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            Recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            Recorder.SetOutputFile(AudioFilePath + "/" + AudioFileName + ".wav");
            Recorder.Prepare();
            Recorder.Start();
        }

        public void StopRecord()
        {
            Recorder.Stop();
            Recorder.Reset();
        }
    }
}
