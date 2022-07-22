namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class InGameItem
    {
        public int TagId { get; set; }
        public IdentifierName ThemeName { get; set; }
        public IdentifierName EmblemShaderName { get; set; }
        public CommonItemData CommonData { get; set; }
        public Configuration[] AvailableConfigurations { get; set; }
    }
}
