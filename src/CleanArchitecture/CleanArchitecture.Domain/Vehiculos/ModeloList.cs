namespace CleanArchitecture.Domain.Vehiculos;


public class ModeloList : List<string>
{

    public static explicit operator string(ModeloList v)
    {
        throw new NotImplementedException();
    }

}