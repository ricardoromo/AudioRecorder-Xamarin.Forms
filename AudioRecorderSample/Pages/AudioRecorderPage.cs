using System;
using Xamarin.Forms;
using System.IO;

namespace AudioRecorderSample.Pages
{ 
	public partial class AudioRecorderPage : ContentPage
	{
		public AudioRecorderPage ()
		{
			Layout ();
			App.AudioPlayer.AudioFilePath = Path.GetTempPath ();
			App.AudioRecorder.AudioFilePath = Path.GetTempPath ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			AudioRecorderButton.Clicked += AudioRecorderButton_Clicked;
			AudioPlayerButton.Clicked += AudioPlayerButton_Clicked;
		}


		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			AudioPlayerButton.Clicked -= AudioPlayerButton_Clicked;
			AudioRecorderButton.Clicked -= AudioRecorderButton_Clicked;
		}

		bool isRecording = false;
		void AudioRecorderButton_Clicked (object sender, EventArgs e)
		{
			if (!isRecording) {
				string audioFileName = Guid.NewGuid ().ToString ();
				App.AudioRecorder.AudioFileName = audioFileName;
				App.AudioPlayer.AudioFileName = audioFileName;
				App.AudioRecorder.StartRecord();
				AudioRecorderButton.Text = "Recording.......";
				isRecording = true;
			} else {
				AudioRecorderButton.Text = "Start Recording";
				App.AudioRecorder.StopRecord ();
				isRecording = false;
			}
		}


		void AudioPlayerButton_Clicked (object sender, EventArgs e)
		{
			if (File.Exists (App.AudioRecorder.AudioFilePath + "/" + App.AudioRecorder.AudioFileName + ".wav"))
				App.AudioPlayer.PlayAudio ();
			else
				DisplayAlert ("Whooops!", "Record something first", "Ok");

		}
	}
}

