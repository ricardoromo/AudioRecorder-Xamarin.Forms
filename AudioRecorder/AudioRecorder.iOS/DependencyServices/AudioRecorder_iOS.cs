using System;
using AudioRecorder.DependencyServices;
using AudioRecorder.iOS.DependencyServices;
using AVFoundation;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(AudioRecorder_iOS))]
namespace AudioRecorder.iOS.DependencyServices
{
	public class AudioRecorder_iOS : IAudioRecorder
	{
		public AVAudioRecorder Recorder { get; set; }
		public NSError Error;
		public NSUrl Url { get; set; }
		public NSDictionary Settings { get; set; }
		public string AudioFileName { get; set; }
		public string AudioFilePath { get; set; }

		public AudioRecorder_iOS()
		{

		}

		public void StartRecord()
		{
			PrepareRecorder();
			Recorder.Record();
		}

		public void StopRecord()
		{
			Recorder.Stop();
		}


		public void PrepareRecorder()
		{
			if (Recorder != null)
			{
				Recorder.Dispose();
			}
			var audioSession = AVAudioSession.SharedInstance();
			var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
			if (err != null)
			{
				Console.WriteLine("audioSession: {0}", err);
			}
			err = audioSession.SetActive(true);
			if (err != null)
			{
				Console.WriteLine("audioSession: {0}", err);
			}

			Console.WriteLine("Audio File Path: " + AudioFilePath + AudioFileName);
			Url = NSUrl.FromFilename(AudioFilePath + AudioFileName + ".wav");

			//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
			NSObject[] values = new NSObject[] {
				NSNumber.FromFloat (44100.0f),
				//Sample Rate
				NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.LinearPCM),
				//AVFormat
				NSNumber.FromInt32 (2),
				//Channels
				NSNumber.FromInt32 (16),
				//PCMBitDepth
				NSNumber.FromBoolean (false),
				//IsBigEndianKey
				NSNumber.FromBoolean (false)
				//IsFloatKey
			};
			//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
			NSObject[] keys = new NSObject[] {
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVLinearPCMBitDepthKey,
				AVAudioSettings.AVLinearPCMIsBigEndianKey,
				AVAudioSettings.AVLinearPCMIsFloatKey
			};

			Settings = NSDictionary.FromObjectsAndKeys(values, keys);
			Recorder = AVAudioRecorder.Create(Url, new AudioSettings(Settings), out Error);
			Recorder.PrepareToRecord();
		}
	}
}
