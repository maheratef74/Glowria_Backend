using Glowria.Domain.Entities;
using Glowria.Domain.IRepository;

namespace Glowria.Infrastructure.Repository;

public class ProductRepository : GenericRepository<Product> , IProductRepository
{
    private readonly AppDbContext _appDbContext;
    
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }
}