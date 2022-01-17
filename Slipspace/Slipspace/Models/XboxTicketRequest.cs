namespace Slipspace.Models
{
    public class XboxTicketRequest
    {
        public string RelyingParty { get; set; }
        public string TokenType { get; set; }
        public XboxTicketProperties Properties { get; set; }
    }
}
