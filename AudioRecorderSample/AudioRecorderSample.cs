using System;
using Xamarin.Forms;
using AudioRecorderSample.Pages;
using AudioRecorderSample.DependenciesServices;

namespace AudioRecorderSample
{
	public class App : Application
	{
		public static AudioRecorder AudioRecorder { get; set;}
		public static AudioPlayer AudioPlayer { get; set;}

		public App ()
		{
			// The root page of your application
			AudioRecorder = DependencyService.Get<AudioRecorder> ();
			AudioPlayer = DependencyService.Get<AudioPlayer> ();
			MainPage = new AudioRecorderPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

