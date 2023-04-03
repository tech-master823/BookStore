using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Products
{
	public class ProductAppService : BookStoreAppService, IProductAppService
	{
		private readonly IRepository<Product, Guid> _productRespository;

		public ProductAppService(IRepository<Product, Guid> productRespository)
		{
			_productRespository = productRespository;
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
	}
}