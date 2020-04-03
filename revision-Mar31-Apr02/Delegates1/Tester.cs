// Advanced C# Constructs: Delegates

namespace Delegates1
{
    public static class Tester
    {
        // in Main we use the higher-order function
        public static void Main()
        {
            // instantiate the storage class
            var ms = new MediaStorage();

            // instantiate the player classes
            var aPlayer = new AudioPlayer();
            var vPlayer = new VideoPlayer();

            // instantiate the delegate
            var aDelegate = new MediaStorage.PlayMedia(aPlayer.PlayAudioFile);
            var vDelegate = new MediaStorage.PlayMedia(vPlayer.PlayVideoFile);

            // provide instances to the method using the delegate
            ms.ReportResult(aDelegate);
            ms.ReportResult(vDelegate);
        }
    }
}