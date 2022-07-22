namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AssetPermission
    {
        public string CanonicalToken { get; set; }
        public int AuthoringRole { get; set; }
        public string GrantedBy { get; set; }
        public APIFormattedDate GrantedOnDateUtc { get; set; }
    }
}
