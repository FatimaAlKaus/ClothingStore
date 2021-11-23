namespace Application.Queries.Product
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;

    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return (await _productRepository.GetAll()).Select(x => x.Adapt<ProductDto>()).ToList();
        }
    }
}
