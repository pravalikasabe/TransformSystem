using System;

namespace Models.TransformSystemApp
{
    /// <summary>
    /// AccountDetail holds the Account File #1 format
    /// </summary>
    class AccountDetailFormat1
    {
        /// <summary>
        ///  Gets or sets the Identifier like 123|AbcCode
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///  Gets or sets the account name like 'My Account'
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets the account type like '1/2/3/4'
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///  Gets or sets the account opened date time 01-01-2018
        /// </summary>
        public DateTime Opened { get; set; }

        /// <summary>
        ///  Gets or sets the Currency type like 'CD/US'
        /// </summary>
        public string Currency { get; set; }

    }
}
