namespace Models.TransformSystemApp
{
    /// <summary>
    /// AccountDetail holds the Account File #2 format
    /// </summary>
    class AccountDetailFormat2
    {
        /// <summary>
        ///  Gets or sets the account name like 'My Account'
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets the account type like 'RRSP/RESP/FUND/TRADING'
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///  Gets or sets the Currency type like 'C/U'
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///  Gets or sets the Currency type
        /// </summary>
        public string CustodianCode { get; set; }

    }

}
