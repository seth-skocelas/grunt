namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class DriverDetails
    {
        public string Minimum { get; set; }
        public string DownloadLink { get; set; }
        public object[] Blocklist { get; set; }
    }
}
