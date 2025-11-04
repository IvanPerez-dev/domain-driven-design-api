using CleanArchitecture.Domain.Roles;
using CleanArchitecture.Domain.UnitTests.Infrastructure;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Users.Events;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.UnitTests.Users;

public class UserTests : BaseTest
{

    [Fact]
    public void Create_Should_SetPropertyValues()
    {

        //Arrange --> Vamos a crear un Mock File-> UserMock

        // Act
        var user = User.Create(
            UserMock.Nombre, 
            UserMock.Apellido, 
            UserMock.Email, 
            UserMock.Password
            );

        // Assert 
        user.Nombre.Should().Be(UserMock.Nombre);
        user.Apellido.Should().Be(UserMock.Apellido);
        user.Email.Should().Be(UserMock.Email);
        user.PasswordHash.Should().Be(UserMock.Password);
    }

    [Fact]
    public void Create_Should_RaiseUserCreateDomainEvent()
    {
        var user = User.Create(
            UserMock.Nombre,
            UserMock.Apellido,
            UserMock.Email,
            UserMock.Password
        );

      
        // var domainEvent = user
        // .GetDomainEvents().OfType<UserCreatedDomainEvent>().SingleOrDefault();

        var domainEvent = AssertDomainEventWasPublished<UserCreatedDomainEvent>(user);


        domainEvent!.UserId.Should().Be(user.Id);
    }


    [Fact]
    public void Create_Should_AddRegisterRoleToUser()
    {
        var user = User.Create(
            UserMock.Nombre,
            UserMock.Apellido,
            UserMock.Email,
            UserMock.Password
        );


        user.Roles.Should().Contain(Role.Cliente);
    }


}