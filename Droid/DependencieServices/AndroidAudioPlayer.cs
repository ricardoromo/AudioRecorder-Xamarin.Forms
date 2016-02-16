using System;
using Xamarin.Forms;
using Android.Media;
using AudioRecorderSample.DependenciesServices;
using AudioRecorderSample.Droid.DependencieServices;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAudioPlayer))]
namespace AudioRecorderSample.Droid.DependencieServices
{
	public class AndroidAudioPlayer : AudioPlayer
	{
		public MediaPlayer Player{ get; set;}
		public AndroidAudioPlayer ()
		{
			Player = new MediaPlayer ();
		}

		#region AudioPlayer implementation

		public void PlayAudio ()
		{
			Player.Completion += (sender, e) => {
				Player.Reset ();
			};
			Player.SetDataSource (AudioFilePath + "/" + AudioFileName + ".wav");
			Player.Prepare ();
			Player.Start ();
		}

		public void StopAudio ()
		{
			Player.Stop (); 
		}

		public void PauseAudio ()
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

