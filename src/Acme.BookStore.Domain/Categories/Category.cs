using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Categories
{
	public class Category : AuditedAggregateRoot<Guid>
	{
		public string Name { get; set; }
	}
}