using Microsoft.AspNetCore.Mvc;
using vpos.contract.Requests;

namespace vpos.contract.Controllers
{
    public interface IPaymentController
    {
        IActionResult Balance([FromBody] BalanceRequest balanceRequest);
        IActionResult Withdraw([FromBody]WithdrawRequest withdrawRequest);
        IActionResult Deposit([FromBody]DepositRequest depositRequest);
    }
}
