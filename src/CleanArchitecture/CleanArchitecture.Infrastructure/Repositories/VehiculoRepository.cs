using CleanArchitecture.Application.Paginations;
using CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;


internal sealed class VehiculoRepository 
: Repository<Vehiculo, VehiculoId>, IVehiculoRepository, IPaginationVehiculoRepository
{
    public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}
