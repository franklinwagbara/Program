namespace Program.Application.Exceptions;

public class NotFoundException(string? message = "This resource was not found.") : Exception(message)
{
}
