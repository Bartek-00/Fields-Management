using FieldsManagment.IntegrationTests;
using System;
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

        // Act
        var response = await client.GetAsync("");
    }
}