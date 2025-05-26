namespace JPZipSharp.Model
{
    public class AddressZipResponse
    {
        public int level { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
        public Address[] addresses { get; set; }
    }

}
