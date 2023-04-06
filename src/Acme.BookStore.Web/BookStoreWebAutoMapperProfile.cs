using Acme.BookStore.Products;
using Acme.BookStore.Web.Pages.Products;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
	public BookStoreWebAutoMapperProfile()
	{
		//Define your AutoMapper configuration here for the Web project.
		CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
	}
}
