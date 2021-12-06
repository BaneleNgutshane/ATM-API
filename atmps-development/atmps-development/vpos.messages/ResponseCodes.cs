using System.Collections.Generic;

namespace vpos.messages
{
    /// <summary>
    /// Response codes.
    /// </summary>
    public enum ResponseCodes
    {
        G1001,
        G1002,
        A1001,
        A1002,
        A1003,
        D1001,
        D1002,
        W1001,
        W1002,
        W1003
    }

    /// <summary>
    /// Response code messages.
    /// </summary>
    public static class ResponseCodeMessages
    {
        public static Dictionary<string, string> List = new Dictionary<string, string>
        {
            {"G1001","ATM_ERR: System Error."},
            {"G1002","ATM_ERR: Internal Error."},
            {"A1001","ACCOUNT_ERR: Account not found!"},
            {"A1002","ACCOUNT_ERR: Account details are not correct."},
            {"A1003","ACCOUNT_ERR: Account details can't be empty."},
            {"D1001","FUNDS_ERR: Deposit amount can't be empty."},
            {"D1002","FUNDS_ERR: Deposit amount can't be less than or equal to zero!"},
            {"W1001","FUNDS_ERR: Withdraw amount can't be empty."},
            {"W1002","FUNDS_ERR: Withdraw amount can't be less than or equal to zero!"},
            {"W1003","FUNDS_ERR: Not enough funds in account to make withdrawal."}

        };
    }
}