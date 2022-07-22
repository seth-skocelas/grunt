namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AuthoringSessionStarter
    {
        public string PreviousVersionId { get; set; }
        public string SessionOrigin { get; set; }
    }

}
