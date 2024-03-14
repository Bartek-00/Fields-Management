using FieldsManagement.Application.Commands.Operations;
using FieldsManagement.Core.Entities;
using FieldsManagment.IntegrationTests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace IntegrationTests;

public class OperationEndpointsTests : IClassFixture<FieldsManagementWebAplicationFactory>
{
    private readonly FieldsManagementWebAplicationFactory _webAppFactory;

    public OperationEndpointsTests(FieldsManagementWebAplicationFactory webAppFactory, ITestOutputHelper testOutputHelper)
    {
        _webAppFactory = webAppFactory;
        _webAppFactory.Output = testOutputHelper;
    }

    [Fact]
    public async Task CRUDOperationTests()
    {
        var client = _webAppFactory.CreateClient();

        var field = new Field(
                       fieldId: Guid.NewGuid(),
                       villageName: "makapaka",
                       area: 30,
                       additionalData: ""
                    );

        var field2 = new Field(
                       fieldId: Guid.NewGuid(),
                       villageName: "znin",
                       area: 15,
                       additionalData: ""
                    );

        await client.PostAsJsonAsync("/Fields", field);
        await client.PostAsJsonAsync("/Fields", field2);

        var getField = await client.GetFromJsonAsync<List<Field>>("/Fields");

        var operation = new CreateOperation(
                       FieldId: getField![0].FieldId,
                       OperationName: "sowing",
                       Description: "sowing seeds",
                       Date: DateTime.Now
                       );
        var operation1 = new CreateOperation(
                       FieldId: getField![0].FieldId,
                       OperationName: "plant",
                       Description: "planting",
                       Date: DateTime.Now
                       );
        var operation2 = new CreateOperation(
                       FieldId: getField![1].FieldId,
                       OperationName: "seed",
                       Description: "",
                       Date: DateTime.Now
                       );

        var responseOperation = await client.PostAsJsonAsync("/Operations", operation);
        var responseOperation1 = await client.PostAsJsonAsync("/Operations", operation1);
        var responseOperation2 = await client.PostAsJsonAsync("/Operations", operation2);
        responseOperation.StatusCode.Should().Be(HttpStatusCode.Created);

        var getOperation = await client.GetFromJsonAsync<List<Operation>>("/Operations");
        getOperation![0].FieldId.Should().Be(getOperation![0].FieldId);
        getOperation![0].OperationName.Should().Be("sowing");
        getOperation.Count.Should().Be(3);
        var getAllFromOnefield = await client.GetFromJsonAsync<List<Operation>>($"/Operations/{getField![0].FieldId}");
        getAllFromOnefield!.Count.Should().Be(2);

        var UpdatedOperation = new UpdateOperation(
                                  OperationId: getOperation![0].OperationId,
                                  FieldId: getField![0].FieldId,
                                  OperationName: "harvest",
                                  Description: "harvesting",
                                  Date: DateTime.Now
                                  );
        var update = await client.PutAsJsonAsync("/Operations", UpdatedOperation);
        update.StatusCode.Should().Be(HttpStatusCode.OK);
        var getUpdatedOperation = await client.GetFromJsonAsync<List<Operation>>("/Operations");

        getUpdatedOperation![0].OperationName.Should().Be("harvest");
        getUpdatedOperation![0].Description.Should().Be("harvesting");

        var delete = await client.DeleteAsync($"/Operations/{getOperation![0].OperationId}");
        delete.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}