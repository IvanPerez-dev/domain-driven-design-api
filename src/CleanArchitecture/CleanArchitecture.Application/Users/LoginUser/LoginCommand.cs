using System.Windows.Input;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Users.LoginUser;


public record LoginCommand(string Email, string Password) : ICommand<string>;