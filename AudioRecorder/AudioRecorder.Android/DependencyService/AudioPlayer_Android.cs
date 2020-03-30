using System;
using Android.Media;
using AudioRecorder.DependencyServices;
using AudioRecorder.Droid.DependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(AudioPlayer_Android))]
namespace AudioRecorder.Droid.DependencyService
{
    public class AudioPlayer_Android : IAudioPlayer
    {
        public string AudioFileName { get; set; }
        public string AudioFilePath { get; set; }

        public MediaPlayer Player { get; set; }
        public AudioPlayer_Android()
        {
            Player = new MediaPlayer();
        }

        public void PauseAudio()
        {
            Player.Pause();
        }

        public void PlayAudio()
        {
            Player.Completion += (sender, e) => {
                Player.Reset();
            };
            Player.SetDataSource(AudioFilePath + "/" + AudioFileName + ".wav");
            Player.Prepare();
            Player.Start();
        }

        public void StopAudio()
        {
            Player.Stop();
        }
    }
}
