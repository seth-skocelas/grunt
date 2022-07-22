namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerGiveaways
    {
        // TODO: This needs to be tweaked to see what giveaways are available
        // and represent that through the correct strongly-typed entity rather
        // than a plain object.
        public object[] GiveawayResults { get; set; }
    }

}
