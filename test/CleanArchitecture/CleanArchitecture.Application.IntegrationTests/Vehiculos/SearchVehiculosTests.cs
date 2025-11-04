using CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using CleanArchitecture.Domain.Abstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace CleanArchitecture.Application.IntegrationTests.Vehiculos;

public class SearchVehiculos : BaseIntegrationTest
{
    public SearchVehiculos(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task SearchVehiculos_ShouldReturnEmptyList_WhenDateRangeInvalid()
    {
        //arrange
            var query = new SearchVehiculosQuery(
                new DateOnly(2023,1,1),
                new DateOnly(2022,1,1)
            );
        //act
            var resultado = await Sender.Send(query);
        //assert

        resultado.Value.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchVehiculos_ShouldReturnVehiculos_WhenDateRangeIsValid()
    {
        var query = new SearchVehiculosQuery(
            new DateOnly(2023,1,1),
            new DateOnly(2026,1,1)
        );

        var resultado = await Sender.Send(query);

        resultado.IsSuccess.Should().BeTrue();

    }




}