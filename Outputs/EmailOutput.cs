// <copyright file="EmailOutput.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog.Outputs
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using SharpLog.Settings;
    using MailAddress = SharpLog.Settings.Wrapper.MailAddress;

    public class EmailOutput : AsyncOutput, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailOutput"/> class.
        /// </summary>
        public EmailOutput()
            : this(null, null, null)
        {
        }

        public EmailOutput(
            SmtpClient client,
            MailAddress from,
            MailAddress[] to,
            string formatSubject = "[$La{l}$] $C$",
            int suspendTime = 5000,
            string format = null,
            LevelContainer levels = null)
            : base(suspendTime, format, levels)
        {
            this.Client = client;
            this.From = from;
            this.To = to;
            this.FormatSubject = formatSubject;
            this.Format = format;

            base.OnStart += this.OnStart;
            base.OnDispose += this.OnDispose;
        }

        public SmtpClient Client { get; set; }

        public MailAddress From { get; set; }

        public MailAddress[] To { get; set; }

        public MailAddress[] Bcc { get; set; }

        public MailAddress[] CC { get; set; }

        public string FormatSubject { get; set; }

        /// <inheritdoc/>
        public override bool WriteNonBlocking((string, Log)[] logs)
        {
            foreach (var log in logs)
            {
                try
                {
                    var message = new MailMessage()
                    {
                        From = new System.Net.Mail.MailAddress(this.From.Address, this.From.DisplayName),
                        Subject = SharpLog.Formatter.Format(this.FormatSubject, log.Item2),
                        IsBodyHtml = true,
                        Body = log.Item1,
                    };

                    if (this.To != null)
                    {
                        foreach (var to in this.To)
                        {
                            message.To.Add(new System.Net.Mail.MailAddress(to.Address, to.DisplayName));
                        }
                    }

                    if (this.Bcc != null)
                    {
                        foreach (var bcc in this.Bcc)
                        {
                            message.Bcc.Add(new System.Net.Mail.MailAddress(bcc.Address, bcc.DisplayName));
                        }
                    }

                    if (this.CC != null)
                    {
                        foreach (var cc in this.CC)
                        {
                            message.CC.Add(new System.Net.Mail.MailAddress(cc.Address, cc.DisplayName));
                        }
                    }

                    this.Client.Send(message);
                }
                catch (Exception e)
                {
                    Logging.LogError("An exception occurred while sending a mail!", typeof(EmailOutput), "SHARPLOG_INTERNAL", e.InnerException);
                }
            }

            return false;
        }

        private new void OnStart(object sender, EventArgs args)
        {
            if (this.Client == null)
            {
                throw new ArgumentNullException("Client", "Property cannot be null!");
            }
            else if (this.From == null)
            {
                throw new ArgumentNullException("FromAdress", "Property cannot be null!");
            }
            else if (this.To == null && this.Bcc == null && this.CC == null)
            {
                throw new ArgumentNullException("To, Bcc, CC", "One receiver must be set!");
            }
        }

        private new void OnDispose(object sender, EventArgs args)
        {
            this.Client.Dispose();
        }
    }
}
