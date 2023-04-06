using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Products
{
	public interface IProductAppService : IApplicationService
	{
		Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);

		Task CreateAsync(CreateUpdateProductDto input);
		Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();
	}
}