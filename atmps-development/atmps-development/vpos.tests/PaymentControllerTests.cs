using AutoFixture;
using Moq;
using vpos.contract.Requests;
using vpos.seb.business.Payments;
using vpos.seb.Controllers;
using Xunit;

namespace vpos.tests
{
    public class PaymentControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<BalanceRequest> _balanceRequest;
        private readonly Mock<IPaymentManager> _iPaymentMock;
        private readonly PaymentController _sut;

        public PaymentControllerTests()
        {
            _fixture = new Fixture();
            _balanceRequest = _fixture.Freeze<Mock<BalanceRequest>>();
            _iPaymentMock = _fixture.Freeze<Mock<IPaymentManager>>();
            _sut = new PaymentController(_iPaymentMock.Object);
        }

        [Fact]
        public void BalanceRequest_ShouldReturnOk_WhenAccountDetailsAreCorrect()
        {
            //Arrange - prepare data which will be required for testing
            
             //mock objects that similate a real object - mock classes and interfaces

             //autofixture - minimize arrange phase - remove the need for hand-coding
             
             //fluent assertions allow to more naturally specify outcome of a TDD or BDD style unit test

            //Act - call method which is being tested making use of the data prepared in the arrange

            //Assert - compare expeected results with actual results to decide whether the test passed or failed

        }
        [Fact]
        public void BalanceRequest_ShouldReturnResponseCpde_WhenAccountDetailsAreIncorrect()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void BalanceRequest_ShouldReturnResponseCpde_WhenAccountNotFound()
        {
            //Arrange

            //Act

            //Assert

        }

    }
    public class DepositRequestTests
    {
        
        [Fact]
        public void DepositRequest_ShouldReturnOk_WhenAccountDetailsAreCorrect()
        {
            //Arrange

            //Act

            //Assert

        }
    }
    public class WithdrawRequestTests
    {
        

        [Fact]
        public void WithdrawRequest_ShouldReturnOk_WhenAccountDetailsAreCorrect()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void WithdrawRequest_ShouldReturnResponseCode_WhenAccountDetailsAreIncorrect()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void WithdrawRequest_ShouldReturnBadRequest_WhenAccountInputIsEqualIsZero()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
