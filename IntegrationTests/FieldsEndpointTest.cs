﻿using FieldsManagement.Core.Entities;
using FieldsManagment.IntegrationTests;
using FluentAssertions;
using MySpot.Core.ValueObjects;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace FieldsManagement.IntegrationTests;

public class FieldsEndpointsTests : IClassFixture<FieldsManagementWebAplicationFactory>
{
    private readonly FieldsManagementWebAplicationFactory _webAppFactory;

    public FieldsEndpointsTests(FieldsManagementWebAplicationFactory webAppFactory, ITestOutputHelper testOutputHelper)
    {
        _webAppFactory = webAppFactory;
        _webAppFactory.Output = testOutputHelper;
    }

    [Fact]
    public async Task CRUDTests()
    {
        var client = _webAppFactory.CreateClient();

        var field = new Field(
            fieldId: Guid.NewGuid(),
            villageName: "makapaka",
            area: 30,
            additionalData: ""
            );

        var response = await client.PostAsJsonAsync("/Fields", field);
        var getReservation = await client.GetFromJsonAsync<List<Field>>("/Fields");
        getReservation!.Count.Should().Be(1);
    }
}