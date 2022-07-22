namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class CommonItemData
    {
        public string Id { get; set; }
        public bool HideUntilOwned { get; set; }
        public DisplayString Title { get; set; }
        public DisplayString Description { get; set; }
        public bool FeatureFlag { get; set; }
        public DisplayString ItemAvailability { get; set; }
        public APIFormattedDate DateReleased { get; set; }
        public DisplayString AltName { get; set; }
        public IdentifierName IconStringId { get; set; }
        public int SpriteBitmap { get; set; }
        public int SpriteFrameIndex { get; set; }
        public int AltSpriteBitmap { get; set; }
        public int AltSpriteFrameIndex { get; set; }
        public DisplayPath DisplayPath { get; set; }
        public string Quality { get; set; }
        public int ManufacturerId { get; set; }
        public string Type { get; set; }
        public string RewardTrack { get; set; }
        public ItemPath[] ParentPaths { get; set; }
        public SortingMetadata SortingMetadata { get; set; }
        public int SeasonNumber { get; set; }
        public int OriginalSeasonNumber { get; set; }
        public DisplayString Season { get; set; }
    }

}
