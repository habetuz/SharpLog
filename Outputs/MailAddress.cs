// <copyright file="MailAddress.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog.Settings.Wrapper
{
    /// <summary>
    /// Class containing a mail address.
    /// </summary>
    public class MailAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailAddress"/> class.
        /// </summary>
        public MailAddress()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailAddress"/> class.
        /// </summary>
        /// <param name="address">The mail address.</param>
        /// <param name="displayName">The display name.</param>
        public MailAddress(string address, string displayName = null)
        {
            this.Address = address;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Gets or sets the mail address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
