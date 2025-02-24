﻿using System;
using Contracting.Domain.Abstractions;
using Contracting.Domain.Shared;

namespace Contracting.Domain.Patients;

public class Patient : AggregateRoot
{
    public FullNameValue Name { get; set; }
    public PhoneNumberValue Phone { get; set; }

    public Patient(string name, string phone) : base(Guid.NewGuid())
    {
        Name = name;
        Phone = phone;
    }

    //Need for EF Core
    private Patient() { }
}