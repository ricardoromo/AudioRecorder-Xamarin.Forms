using System;

namespace AudioRecorderSample.DependenciesServices
{
	public interface AudioRecorder
	{
		void StartRecord();
		void StopRecord();
		string AudioFileName{ get; set;}
		string AudioFilePath{ get; set;}
	}
}

