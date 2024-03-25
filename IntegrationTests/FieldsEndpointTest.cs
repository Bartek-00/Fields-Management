using FieldsManagement.Application.Commands;
using FieldsManagement.Application.Commands.Login;
using FieldsManagement.Application.DTO;
using FieldsManagement.Core.Entities;
using FieldsManagment.IntegrationTests;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
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

        var field2 = new Field(
            fieldId: Guid.NewGuid(),
            villageName: "znin",
            area: 30,
            additionalData: ""
            );
        //create
        var response = await client.PostAsJsonAsync("/Fields", field);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var getField = await client.GetFromJsonAsync<List<Field>>("/Fields");

        //update
        var UpdatedField = new UpdateField(
                       Id: getField![0].FieldId,
                       AdditionalData: "updated"
                        );
        var update = await client.PutAsJsonAsync("/Fields", UpdatedField);
        update.StatusCode.Should().Be(HttpStatusCode.OK);

        var getFields3 = await client.GetFromJsonAsync<List<Field>>("/Fields");
        getFields3![0].AdditionalData.Should().Be("updated");

        //delete
        var delete = await client.DeleteAsync($"/Fields/{getField![0].FieldId}");
        delete.StatusCode.Should().Be(HttpStatusCode.NoContent);

        //get
        await client.PostAsJsonAsync("/Fields", field);
        await client.PostAsJsonAsync("/Fields", field);
        await client.PostAsJsonAsync("/Fields", field);
        await client.PostAsJsonAsync("/Fields", field2);

        var getFields2 = await client.GetFromJsonAsync<List<Field>>("/Fields");
        var response2 = await client.GetFromJsonAsync<List<Field>>("/Fields/Village/makapaka");
        getFields2!.Count.Should().Be(4);
        response2!.Count.Should().Be(3);
    }
}