using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    /// <summary>
    /// For more information on pseudo-locales, refer to the documentation:
    /// https://docs.microsoft.com/windows/win32/intl/pseudo-locales
    /// </summary>
    public class Translations
    {
        [JsonProperty("es-es")]
        public string Spanish { get; set; }

        [JsonProperty("qps-ploc")]
        public string BasePseudoLocale { get; set; }

        [JsonProperty("qps-ploca")]
        public string EastAsianLanguagePseudoLocale { get; set; }

        [JsonProperty("qps-plocm")]
        public string MirroredPseudoLocale { get; set; }
    }

}
