using MyInvestments.Wallet.Domain.Enums;

namespace MyInvestments.Wallet.Tests
{
    public class OperationTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_an_operation_with_less_than_or_equal_zero_quantity_should_throw_an_exception(int quantity)
        {
            var walletId = Guid.NewGuid();
            var stockId = 123;
            var unitPrice = 4;
            var type = OperationType.Buy;
            var date = DateTime.Now;

            Assert.Throws<Exception>(() => new Operation(walletId,stockId,quantity,unitPrice,type,date));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1.54)]
        public void Create_an_operation_with_less_than_or_equal_zero__should_throw_an_exception(decimal unitPrice)
        {
            var walletId = Guid.NewGuid();
            var stockId = 321;
            var quantity = 78;
            var type = OperationType.Sell;
            var date = DateTime.Now;

            Assert.Throws<Exception>(() => new Operation(walletId, stockId, quantity, unitPrice, type, date));
        }
    }
}
