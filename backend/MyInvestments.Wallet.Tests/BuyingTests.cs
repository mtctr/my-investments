namespace MyInvestments.Wallet.Tests
{
    public class BuyingTests
    {
        private readonly StockWallet _wallet;
        public BuyingTests()
        {
            _wallet = new StockWallet("Test Wallet");
        }
        
        [Fact]        
        public void Buying_new_stocks_should_add_item_to_wallet()
        {            
            var stockId = 96;
            var quantity = 10;
            var unitPrice = 35;            

            Assert.False(_wallet.HasStock(stockId));

            BuyStocks(stockId, quantity, unitPrice);
            Assert.True(_wallet.HasStock(stockId));
        }

        [Fact]
        public void Buying_existent_stocks_should_increase_item_quantity()
        {
            var stockId = 96;
            var initialQuantity = 10;
            var unitPrice = 35;
            
            Assert.False(_wallet.HasStock(stockId));
            
            BuyStocks(stockId, initialQuantity, unitPrice);
            Assert.True(_wallet.HasStock(stockId));

            var quantityToAdd = 15;
            BuyStocks(stockId, quantityToAdd, unitPrice);

            var quantityThatShouldBe = initialQuantity + quantityToAdd; 
            var actualQuantity = _wallet.GetStocksCount(stockId);
            Assert.Equal(quantityThatShouldBe, actualQuantity);
        }

        private void BuyStocks(int stockId,int quantity,decimal unitPrice)
        {
            var type = OperationType.Buy;
            var date = DateTime.Now;
            var operation = new Operation(_wallet.Id, stockId, quantity, unitPrice, type, date);
            _wallet.ExecuteOperation(operation);
        }
    }
}
