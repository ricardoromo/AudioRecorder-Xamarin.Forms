using System;

namespace AudioRecorderSample.DependenciesServices
{
	public interface AudioPlayer
	{
		void PlayAudio ();
		void StopAudio ();
		void PauseAudio ();
		string AudioFileName{ get; set;}
		string AudioFilePath{ get; set;}
	}
}

