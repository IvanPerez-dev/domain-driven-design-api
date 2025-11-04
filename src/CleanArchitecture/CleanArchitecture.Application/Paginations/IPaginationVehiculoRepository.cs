using System.Linq.Expressions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehiculos;
using LinqKit;
using Microsoft.EntityFrameworkCore.Query;

namespace CleanArchitecture.Application.Paginations;

public interface IPaginationVehiculoRepository
{

    Task<PagedResults<Vehiculo, VehiculoId>> GetPaginationAsync(

        Expression<Func<Vehiculo, bool>>? predicate,
        Func<IQueryable<Vehiculo>, IIncludableQueryable<Vehiculo, object>> includes,
        int page,
        int pageSize,
        string orderBy,
        bool ascending,
        bool disableTracking = true
    );

    Task<PagedResults<Vehiculo, VehiculoId>> GetPaginationAlternativeAsync
    (

        Expression<Func<Vehiculo, bool>>? predicate,
        Func<IQueryable<Vehiculo>, IIncludableQueryable<Vehiculo, object>> includes,
        int page,
        int pageSize,
        Expression<Func<Vehiculo, object>>? OrderBy,
        bool OrderByAsc = true,
        bool disableTracking = true
    );


}