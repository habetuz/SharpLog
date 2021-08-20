// <copyright file="MassLogger.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace SharpLog
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Extends <see cref="Logger"/> to log a massive amount of info logs. It does that by collecting info logs and logging them together and compressed at specific intervals.
    /// </summary>
    public class MassLogger : Logger
    {
        private readonly Dictionary<string, int> pairs = new Dictionary<string, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MassLogger"/> class.
        /// </summary>
        /// <param name="logPause">The pause between two info logs in milliseconds.</param>
        public MassLogger(int logPause = 30000) : base()
        {
            System.Timers.Timer timer = new System.Timers.Timer(logPause);
            timer.Elapsed += this.Log;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        /// <summary>
        /// Gets or sets the text that is displayed before the info log.
        /// </summary>
        public string InfoLogText { get; set; } = string.Empty;

        /// <summary>
        /// Logs to the console with time, origin and type information.
        /// </summary>
        /// <param name="text">The text to be logged</param>
        /// <param name="type">The type of the log. </param>
        /// <param name="instant">If true, every log, and especially <see cref="LoggerType.Info"/>, gets logged instantly.</param>
        public void Log(string text, LogType type = LogType.Debug, bool instant = false)
        {
            if (instant)
            {
                base.Log(text, type);
            }
            else
            {
                if (type != LogType.Info)
                {
                    base.Log(text, type);
                    return;
                }

                if (this.pairs.ContainsKey(text))
                {
                    this.pairs[text]++;
                }
                else
                {
                    this.pairs.Add(text, 1);
                }
            }
        }

        private void Log(object source, System.Timers.ElapsedEventArgs e)
        {
            int[] values = (new List<int>(pairs.Values)).ToArray();
            int maxLength = (values.Max() + "").Length;
            string text = this.InfoLogText + "\n";
            foreach (KeyValuePair<string, int> entry in this.pairs)
            {
                string value = (entry.Value + "").PadLeft(maxLength, ' ');
                text += "| " + string.Format("{0}x {1}", value, entry.Key) + "\n";
            }
            base.Log(text, LogType.Info);
            this.pairs.Clear();
        }
    }
}