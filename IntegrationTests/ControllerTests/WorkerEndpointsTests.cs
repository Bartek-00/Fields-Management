using FieldsManagement.Application.Commands.Users;
using FieldsManagement.Core.Entities;
using FluentAssertions;
using IntegrationTests.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace IntegrationTests.ControllerTests;

public class WorkerEndpointsTests : IClassFixture<FieldsManagementWebAplicationFactory>
{
    private readonly FieldsManagementWebAplicationFactory _webAppFactory;

    public WorkerEndpointsTests(FieldsManagementWebAplicationFactory webAppFactory, ITestOutputHelper testOutputHelper)
    {
        _webAppFactory = webAppFactory;
        _webAppFactory.Output = testOutputHelper;
    }

    [Fact]
    public async Task WorkerEndpointsTest()
    {
        var client = _webAppFactory.CreateClient();

        var worker = new CreateWorker(
                             workerName: "John",
                             workerSurname: "Doe",
                             additionalData: "123456789"
                             );

        var addWorker = await client.PostAsJsonAsync("/Worker", worker);
        addWorker.StatusCode.Should().Be(HttpStatusCode.Created);

        var getWorkers = await client.GetFromJsonAsync<List<Worker>>("/Worker");
        getWorkers!.Count.Should().Be(1);

        var deleteWorker = await client.DeleteAsync($"/Worker/{getWorkers![0].Id}");
        deleteWorker.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}