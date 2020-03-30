using System.IO;
using AudioRecorder.DependencyServices;
using AudioRecorder.iOS.DependencyServices;
using AVFoundation;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(AudioPlayer_iOS))]
namespace AudioRecorder.iOS.DependencyServices
{
    public class AudioPlayer_iOS : IAudioPlayer
    {
        public AVAudioPlayer Player { get; set; }
        public NSError Error;

        public string AudioFileName { get; set; }
        public string AudioFilePath { get; set; }

        public AudioPlayer_iOS()
        {
        }

        public void PauseAudio()
        {
            Player.Pause();
        }

        public void PlayAudio()
        {
            Player = new AVAudioPlayer(NSUrl.FromFilename(Path.Combine(AudioFilePath, AudioFileName + ".wav")), ".wav", out Error);
            Player.Play();
        }

        public void StopAudio()
        {
            Player.Stop();
        }
    }
}
