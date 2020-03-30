
namespace AudioRecorder.DependencyServices
{
    public interface IAudioRecorder
    {
        void StartRecord();
        void StopRecord();
        string AudioFileName { get; set; }
        string AudioFilePath { get; set; }
    }
}
