namespace SharpLog.Settings.Wrapper
{
    public class MailAddress
    {
        public MailAddress()
            : this(null, null)
        {
        }

        public MailAddress(string address, string displayName = null)
        {
        }

        public new string Address { get; set; }

        public new string DisplayName { get; set; }
    }
}
