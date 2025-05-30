﻿using System;
using Contracting.Domain.Delivery;

namespace Contracting.Test.Domain.DeliveryDays;

public class DeliveryDaysTest
{
    [Fact]
    public void CreateDeliveryDays()
    {
        Guid contractId = Guid.NewGuid();
        DateTime date = DateTime.Now.ToUniversalTime();
        string street = "Street";
        int number = 10;
        var rand = new Random();
        double longitude = rand.NextDouble() * 180 - 90;
        double latitude = rand.NextDouble() * 360 - 180;

        var deliveryDay = new DeliveryDay(contractId, date, street, number, longitude, latitude);

        Assert.NotNull(deliveryDay);
        Assert.Equal(contractId, deliveryDay.ContractId);
        Assert.Equal(date, deliveryDay.Date);
        Assert.Equal(street, deliveryDay.Street);
        Assert.Equal(longitude, deliveryDay.Longitude);
        Assert.Equal(latitude, deliveryDay.Latitude);
    }

    [Fact]
    public void UpdateDeliveryDay()
    {
        Guid contractId = Guid.NewGuid();
        DateTime date = DateTime.Now.ToUniversalTime();
        string street = "Street";
        int number = 10;
        var rand = new Random();
        double longitude = rand.NextDouble() * 180 - 90;
        double latitude = rand.NextDouble() * 360 - 180;

        var deliveryDay = new DeliveryDay(contractId, date, street, number, longitude, latitude);

        Assert.NotNull(deliveryDay);
        Assert.Equal(contractId, deliveryDay.ContractId);
        Assert.Equal(date, deliveryDay.Date);
        Assert.Equal(street, deliveryDay.Street);
        Assert.Equal(longitude, deliveryDay.Longitude);
        Assert.Equal(latitude, deliveryDay.Latitude);

        string newStreet = "New Street";
        int newNumber = 20;
        double newLongitude = rand.NextDouble() * 180 - 90;
        double newLatitude = rand.NextDouble() * 360 - 180;

        deliveryDay.Update(newStreet, newNumber, newLongitude, newLatitude);

        Assert.Equal(newStreet, deliveryDay.Street);
        Assert.Equal(newNumber, deliveryDay.Number);
        Assert.Equal(newLatitude, deliveryDay.Latitude, 4);
        Assert.Equal(newLongitude, deliveryDay.Longitude, 4);
    }
}
