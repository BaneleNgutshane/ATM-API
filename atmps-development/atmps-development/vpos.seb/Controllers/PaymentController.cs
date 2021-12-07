using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vpos.contract.Controllers;
using vpos.contract.Requests;
using vpos.seb.business.Payments;

namespace vpos.seb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase, IPaymentController
    {
        public IPaymentManager PaymentManager { get; }

        public PaymentController(IPaymentManager paymentManager)
        {
            PaymentManager = paymentManager;
        }
        
        [HttpPost("Balance_enquiry")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        

        public IActionResult Balance([FromBody] BalanceRequest balanceRequest)
        {
            var response = PaymentManager.Balance(new BalanceOperation
            {
                AccountNumber = balanceRequest.AccountNumber,
                PinCode = balanceRequest.PinCode
            });

            if (!response.IsSuccess)
            {
                return BadRequest(response.Error);
            }

            return Ok(response.Value);
        }


        [HttpPost("Withdraw_cash")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Withdraw([FromBody] WithdrawRequest withdrawRequest)
        {
            var response = PaymentManager.Withdraw(new WithdrawOperation
            {
                AccountNumber = withdrawRequest.AccountNumber,
                PinCode = withdrawRequest?.PinCode,
                WithdrawAmount = withdrawRequest.WithdrawAmount
            });

            if (!response.IsSuccess)
            {
                return BadRequest(response.Error);
            }

            return Ok();
        }

        
        [HttpPost("Deposit_cash")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Deposit([FromBody] DepositRequest depositRequest)
        {
            var response = PaymentManager.Deposit(new DepositOperation
            {
                AccountNumber = depositRequest.AccountNumber,
                PinCode = depositRequest.PinCode,
                DepositAmount = depositRequest.DepositAmount
            });

            if (!response.IsSuccess)
            {
                return BadRequest(response.Error);
            }

            return Ok();
        }
    }
}
