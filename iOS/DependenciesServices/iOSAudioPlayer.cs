using System;
using Xamarin.Forms;
using AudioRecorderSample.DependenciesServices;
using AudioRecorderSample.iOS;
using AVFoundation;
using Foundation;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(iOSAudioPlayer))]
namespace AudioRecorderSample.iOS
{
	public class iOSAudioPlayer : AudioPlayer
	{
		public AVAudioPlayer Player {get; set;}
		public NSError Error;
		public iOSAudioPlayer ()
		{
		}

		#region AudioPlayer implementation

		void AudioPlayer.PlayAudio ()
		{
			Player= new AVAudioPlayer(NSUrl.FromFilename(Path.Combine(AudioFilePath, AudioFileName + ".wav")),".wav",out Error);
			Player.Play();
		}

		void AudioPlayer.StopAudio ()
		{
			Player.Stop ();
		}

		void AudioPlayer.PauseAudio ()
		{
			Player.Pause ();
		}

		private string audioFileName;
		public string AudioFileName {
			get {
				return audioFileName;
			}
			set {
				audioFileName = value;
			}
		}

		private string audioFilePath;
		public string AudioFilePath {
			get {
				return audioFilePath;
			}
			set {
				audioFilePath = value;
			}
		}


		#endregion
	}
}

