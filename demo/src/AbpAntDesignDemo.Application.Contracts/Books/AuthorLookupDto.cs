using System;
using Volo.Abp.Application.Dtos;

namespace AbpAntDesignDemo.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
