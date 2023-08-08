using System;

/* References That Helped Me:
    Task.WhenAll():
    - https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.whenall?view=net-7.0
    - https://stackoverflow.com/questions/18310996/why-should-i-prefer-single-await-task-whenall-over-multiple-awaits
    - https://stackoverflow.com/questions/25009437/running-multiple-async-tasks-and-waiting-for-them-all-to-complete */


namespace ProductNamespace {
    public class ProductInfo {
        public int ProductId;
        public decimal Price;
        public int Stock;

        public async Task<decimal> GetProductPriceAsync(int prodId) {
            return prodId;
        }

        public async Task<int> GetProductStockAsync(int prodId) {
            return prodId;
        }


        public async Task<ProductInfo> GetProductInfoAsync(int productId) {

            Task<decimal> priceTask = Task.Run(() => GetProductPriceAsync(productId));
            Task<int> stockTask = Task.Run(() => GetProductStockAsync(productId));

            await Task.WhenAll(priceTask, stockTask);

            decimal price = await priceTask;
            int stock = await stockTask;

            return new ProductInfo {
                ProductId = productId,
                Price = price,
                Stock = stock,
            };
        }

        public static void Main() {
            ProductInfo p = new();

            Console.WriteLine("Hello from Main");
            Console.WriteLine(p.GetProductInfoAsync(3));
        }
        
    }
}