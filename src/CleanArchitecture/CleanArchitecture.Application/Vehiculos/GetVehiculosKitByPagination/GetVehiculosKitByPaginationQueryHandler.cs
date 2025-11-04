using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Paginations;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Vehiculos;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehiculos.GetVehiculosKitByPagination;


internal sealed class GetVehiculosKitByPaginationQueryHandler :
IQueryHandler<GetVehiculosKitByPaginationQuery, PagedResults<Vehiculo, VehiculoId>>
{
    private readonly IPaginationVehiculoRepository _paginationVehiculoRepository;

    public GetVehiculosKitByPaginationQueryHandler(IPaginationVehiculoRepository paginationVehiculoRepository)
    {
        _paginationVehiculoRepository = paginationVehiculoRepository;
    }

    public async Task<Result<PagedResults<Vehiculo, VehiculoId>>> Handle(
        GetVehiculosKitByPaginationQuery request, CancellationToken cancellationToken
        )
    {

        var predicatea = PredicateBuilder.New<Vehiculo>(true);


        if (!string.IsNullOrEmpty(request.Search))
        {
            predicatea = predicatea.And(y => y.Modelo!.Value.Contains(request.Search));
        }

        var m = new Modelo(request.OrderBy!);

        
        Expression<Func<Vehiculo, object>>? OrderBySelector = request.OrderBy?.ToLower() switch
        {
            "modelo" => vehiculo => vehiculo.Modelo!.Value,
            "vin" => vehiculo => vehiculo.Vin!,
            _ => vehiculo => vehiculo.Modelo!.Value!
        };


        return await _paginationVehiculoRepository.GetPaginationAlternativeAsync(
             predicatea,
            p => p.Include(x => x.Direccion!),
            request.PageNumber,
            request.PageSize,
            OrderBySelector,
            request.OrderAsc
        );
    }
}