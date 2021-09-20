using System;

namespace Models.TransformSystemApp
{
    /// <summary>
    /// AccountDetail holds the Account File #1 format
    /// </summary>
    class AccountDetailTargetFormat
    {
        /// <summary>
        ///  Gets or sets the Identifier like custodian code
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///  Gets or sets the account name like 'My Account'
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets the account type like 'RRSP/RESP/FUND/TRADING'
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///  Gets or sets the account opened date time like '2018-01-01'
        /// </summary>
        public DateTime? Opened { get; set; }

        /// <summary>
        ///  Gets or sets the Currency type like CAD, USD
        /// </summary>
        public string Currency { get; set; }

    }
}
