﻿namespace Contracting.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public List<DomainEvent> _domainEvents;
	public ICollection<DomainEvent> DomainEvents => _domainEvents;

    public Entity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty", nameof(id));
        }
        Id = id;
        _domainEvents = new List<DomainEvent>();
    }

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected Entity()
    {
        _domainEvents = new List<DomainEvent>();
    }
}
