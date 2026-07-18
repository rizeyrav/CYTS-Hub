using Domain.Common.Exceptions;

namespace Domain.Organization.Exceptions;

public sealed class OrganizationException : DomainException
{
    public OrganizationException(string message) : base(message)
    {
        
    }
}