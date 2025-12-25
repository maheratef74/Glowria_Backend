using Glowria.Domain.Entities;
using Glowria.Domain.IRepository;

namespace Glowria.Infrastructure.Repository;

public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
{
    private readonly AppDbContext _appDbContext;
    
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }
}