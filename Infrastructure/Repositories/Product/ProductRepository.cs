using Domain.Common.Repository;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories.Product;

public class ProductRepository : BaseRepository<Domain.Entities.Product, ApplicationDbContext>
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}