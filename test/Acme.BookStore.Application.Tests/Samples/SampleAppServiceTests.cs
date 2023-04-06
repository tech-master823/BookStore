using Acme.BookStore.Products;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public class SampleAppServiceTests : BookStoreApplicationTestBase
{
	private readonly IIdentityUserAppService _userAppService;
	private readonly IProductAppService _productAppService;

	public SampleAppServiceTests()
	{
		_userAppService = GetRequiredService<IIdentityUserAppService>();
		_productAppService = GetRequiredService<IProductAppService>();
	}

	[Fact]
	public async Task Initial_Data_Should_Contain_Admin_User()
	{
		//Act
		var result = await _userAppService.GetListAsync(new GetIdentityUsersInput());

		//Assert
		result.TotalCount.ShouldBeGreaterThan(0);
		result.Items.ShouldContain(u => u.UserName == "admin");
	}

	[Fact]
	public async Task Should_Get_Product_List()
	{
		//Act
		var output = await _productAppService.GetListAsync(new PagedAndSortedResultRequestDto());

		//Assert
		output.TotalCount.ShouldBe(4);
		output.Items.ShouldContain(x => x.Name.Contains("The Hobbit"));
	}
}
