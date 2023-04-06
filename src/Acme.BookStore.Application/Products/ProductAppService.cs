using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Acme.BookStore.Categories;

namespace Acme.BookStore.Products
{
	public class ProductAppService : BookStoreAppService, IProductAppService
	{
		private readonly IRepository<Product, Guid> _productRespository;
		private readonly IRepository<Category, Guid> _categoryRespository;

		public ProductAppService(IRepository<Product, Guid> productRespository,
			IRepository<Category, Guid> categoryRespository)
		{
			_productRespository = productRespository;
			_categoryRespository = categoryRespository;
		}

		public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
		{

			var queryable = await _productRespository.WithDetailsAsync(x => x.Category);

			queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(input.Sorting ?? nameof(Product.Name));

			var products = await AsyncExecuter.ToListAsync(queryable);
			var count = await _productRespository.GetCountAsync();

			return new PagedResultDto<ProductDto>(
				count,
				ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
			);

		}


		public async Task CreateAsync(CreateUpdateProductDto input)
		{
			await _productRespository.InsertAsync(
				ObjectMapper.Map<CreateUpdateProductDto, Product>(input)
			);
		}

		public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync()
		{
			var categories = await _categoryRespository.GetListAsync();
			return new ListResultDto<CategoryLookupDto>(
				ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories)
			);
		}
		// The GetAsync method uses productRepository.GetAsync to get the product
		// from the database and returns it by mapping it to a ProductDto object
		public async Task<ProductDto> GetAsync(Guid id)
		{
			return ObjectMapper.Map<Product, ProductDto>(
			await _productRespository.GetAsync(id)
			);
		}
		// UpdateAsync method gets the product and maps the given input properties to the product's properties.
		public async Task UpdateAsync(Guid id, CreateUpdateProductDto
		input)
		{
			var product = await _productRespository.GetAsync(id);
			ObjectMapper.Map(input, product);
		}
	}
}