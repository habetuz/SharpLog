namespace SharpLog.Settings
{
    public class Level
    {
        public Level() : this('-', true, null) { }

        public Level(
            char @short = '-',
            bool enabled = true,
            string format = null)
        {
            Short = @short;
            Enabled = enabled;
            Format = format;
        }

        public bool Enabled { get; set; }
        public string Format { get; set; }
        public char Short { get; set; }
    }
}