// <copyright file="MassLogger.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace SharpLog
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extends <see cref="Logger"/> to log a massive amount of info logs. It does that by collecting info logs and logging them together and compressed at specific intervals.
    /// </summary>
    public class MassLogger : Logger
    {
        /// <summary>
        /// A dictionary containing logs and how often they were logged.
        /// </summary>
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
        /// <param name="log">The object to be logged</param>
        /// <param name="type">The type of the log. </param>
        /// <param name="instant">If true, every log, and especially <see cref="LogType.Info"/>, gets logged instantly.</param>
        public void Log(object log, LogType type = LogType.Debug, bool instant = false)
        {
            if (instant)
            {
                base.Log(log, type);
            }
            else
            {
                if (type != LogType.Info)
                {
                    base.Log(log, type);
                    return;
                }

                if (this.pairs.ContainsKey(log.ToString()))
                {
                    this.pairs[log.ToString()]++;
                }
                else
                {
                    this.pairs.Add(log.ToString(), 1);
                }
            }
        }

        /// <summary>
        /// Method that gets executed every <see cref="logPause"/> milliseconds to log the logs in <see cref="pairs"/> as info log.
        /// </summary>
        /// <param name="source">The sender of the <see cref="System.Timers.Timer"/></param> event.
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> given by the <see cref="System.Timers.Timer"/></param>
        private void Log(object source, System.Timers.ElapsedEventArgs e)
        {
            int[] values = (new List<int>(this.pairs.Values)).ToArray();
            int maxLength = (values.Max() + string.Empty).Length;
            string text = this.InfoLogText + "\n";
            foreach (KeyValuePair<string, int> entry in this.pairs)
            {
                string value = (entry.Value + string.Empty).PadLeft(maxLength, ' ');
                text += "| " + string.Format("{0}x {1}", value, entry.Key) + "\n";
            }

            base.Log(text, LogType.Info);
            this.pairs.Clear();
        }
    }
}