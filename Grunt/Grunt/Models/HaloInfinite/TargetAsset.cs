namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class TargetAsset
    {
        public string TargetAssetId { get; set; }
        public object TargetAssetVersionId { get; set; }
        public int Order { get; set; }
    }
}
