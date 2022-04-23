namespace SharpLog.Settings
{
    public class Tag
    {
        public Tag() : this(true, null, null, null)
        {
        }

        public Tag(
            bool enabled = true,
            string format = null,
            LevelContainer levels = null,
            OutputContainer outputs = null)
        {
            Enabled = enabled;
            Format = format;
            Levels = levels;
            Outputs = outputs;
        }


        public bool Enabled { get; set; }
        public string Format { get; set; }
        public LevelContainer Levels { get; set; }
        public OutputContainer Outputs { get; set; }
    }
}