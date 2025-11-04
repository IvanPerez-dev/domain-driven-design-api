using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos.Specifications;

public class VehiculoPaginationSpecification : BaseSpecification<Vehiculo, VehiculoId>
{

    public VehiculoPaginationSpecification(
        string sort, 
        int pageIndex,
        int pageSize,
        string search
        ): base(
            x => string.IsNullOrEmpty(search) || x.Modelo!.Value.Contains(search)
        )
    {

            ApplyPaging(  pageSize*(pageIndex-1), pageSize  );

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "modeloAsc": AddOrderBy(p => p.Modelo!.Value);break;
                    case "modeloDesc": AddOrderByDescending(p => p.Modelo!.Value);break;
                    default: AddOrderBy(p => p.FechaUltimaAlquiler!);break;
                }
            }
            else{
                AddOrderBy(p => p.FechaUltimaAlquiler!);               
            }
    }
}