﻿using Application.Exceptions;
using Domain.Common.Repository;
using Infrastructure.Repositories.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Commands.Update;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IOrderRepository _repository;

    public UpdateOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _repository.GetEntityByIdAsync(request.Id, cancellationToken);
        if (order == null || order.Id != request.Id)
        {
            throw new NotFoundException(nameof(order), request.Id);
        }
        order.Result.Count = request.Count;
        order.Result.ProductId = request.ProductId;
        return await _repository.UpdateEntityAsync(order.Result, cancellationToken);
    }
}