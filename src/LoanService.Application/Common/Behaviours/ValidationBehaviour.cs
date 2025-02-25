﻿using FluentValidation;

using MediatR;

using ValidationException = LoanService.Application.Common.Exceptions.ValidationException;

namespace LoanService.Application.Common.Behaviours;

internal class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour( IEnumerable<IValidator<TRequest>> validators )
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle( TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if ( !_validators.Any( ) ) { return await next( ); }

        var context = new ValidationContext<TRequest>( request );

        var validationResults = await Task.WhenAll( _validators.Select( v => v.ValidateAsync( context, cancellationToken ) ) );

        var failures = validationResults .Where( r => r.Errors.Any( ) ).SelectMany( r => r.Errors ).ToList( );

        return failures.Any() ? throw new ValidationException( failures ) : await next();
    }
}
