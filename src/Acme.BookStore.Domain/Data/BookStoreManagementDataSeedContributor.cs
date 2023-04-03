using Acme.BookStore.Categories;
using Acme.BookStore.Products;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Data
{
	public class BookStoreManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
	{
		private readonly IRepository<Category, Guid> _categoryRepository;
		private readonly IRepository<Product, Guid> _productRepository;

		public BookStoreManagementDataSeedContributor(
			IRepository<Category, Guid> categoryRepository,
			IRepository<Product, Guid> productRepository)
		{
			_categoryRepository = categoryRepository;
			_productRepository = productRepository;
		}

		public async Task SeedAsync(DataSeedContext context)
		{
			if (await _categoryRepository.CountAsync() > 0)
			{
				return;
			}

			var adventures = new Category { Name = "Adventures" };
			var fictions = new Category { Name = "Fictions" };

			await _categoryRepository.InsertManyAsync(
			new[]
			{
					adventures,
					fictions
			}
			);
			var adventure1 = new Product
			{
				Category = adventures,
				Name = "The Hobbit",
				Price = 10,
				ReleaseDate = new DateTime(1937, 9, 21),
				StockState = ProductStockState.InStock
			};

			var adventure2 = new Product
			{
				Category = adventures,
				Name = "The Hobbity",
				Price = 10838,
				ReleaseDate = new DateTime(1937, 9, 21),
				StockState = ProductStockState.NotAvailable
			};

			var fiction1 = new Product
			{
				Category = fictions,
				Name = "The Lord of the Rings",
				Price = 20,
				ReleaseDate = new DateTime(1954, 7, 29),
				StockState = ProductStockState.InStock
			};

			var fiction2 = new Product
			{
				Category = fictions,
				Name = "The Lord of the Ringagags",
				Price = 20,
				ReleaseDate = new DateTime(1954, 7, 29),
				StockState = ProductStockState.PreOrder
			};

			await _productRepository.InsertManyAsync(
			new[]
			{
					adventure1,
					adventure2,
					fiction1,
					fiction2
			}
			);

		}

	}

}