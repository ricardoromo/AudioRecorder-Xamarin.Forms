using System;
using Xamarin.Forms;
using Android.Media;
using AudioRecorderSample.DependenciesServices;
using AudioRecorderSample.Droid.DependencieServices;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAudioRecorder))]
namespace AudioRecorderSample.Droid.DependencieServices
{
	public class AndroidAudioRecorder : AudioRecorder
	{
		public MediaRecorder Recorder{ get; set;}
		public AndroidAudioRecorder ()
		{
			Recorder = new MediaRecorder ();
		}

		#region AudioRecorder implementation
		public void StartRecord ()
		{
			Recorder.SetAudioSource (AudioSource.Mic);
			Recorder.SetOutputFormat (OutputFormat.ThreeGpp);
			Recorder.SetAudioEncoder (AudioEncoder.AmrNb);
			Recorder.SetOutputFile (AudioFilePath + "/" + AudioFileName + ".wav");
			Recorder.Prepare ();
			Recorder.Start ();
		}

		public void StopRecord ()
		{
			Recorder.Stop ();
			Recorder.Reset ();
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

