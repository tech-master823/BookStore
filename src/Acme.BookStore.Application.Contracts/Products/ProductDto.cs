using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Products
{
	public class ProductDto : AuditedEntityDto<Guid>
	{
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public bool IsFreeCargo { get; set; }
		public DateTime ReleaseDate { get; set; }
		public ProductStockState StockState { get; set; }
	}

	public class CreateUpdateProductDto {
		public Guid CategoryId { get; set; }
		[Required]
		[StringLength(ProductsConsts.MaxNameLength)]
		public string Name { get; set; }
		public float Price { get; set; }
		public bool IsFreeCargo { get; set; }
		public DateTime ReleaseDate { get; set; }
		public ProductStockState StockState { get; set; }
	}

	public class CategoryLookupDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}