using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Sales.Backoffice.Application.Handlers.Commands;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Tests.Handlers.Commands;

public class CreateDepartmentRequestHandlerTests
{
    private readonly ServiceProvider _serviceProvider;
    private readonly ILogger<CreateDepartmentRequestHandler> _logger;
    public CreateDepartmentRequestHandlerTests()
    {
        _serviceProvider = new Helpers().GetServiceProvider();
        var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger<CreateDepartmentRequestHandler>();
    }

    [Fact]
    public async Task Handle_DepartmentAlreadyExists_ReturnsBadRequest()
    {
        // Arrange
        var command = new CreateDepartmentRequest() { DepartmentType = 0, MaxAcceptableEmployees = 2, SalaryBase = 5000 };

        var departmentRepositoryMock = new Mock<IDepartmentRepository>();
        departmentRepositoryMock.Setup(x => x.GetByTypeAsync(It.IsAny<DepartmentType>()))
            .ReturnsAsync(new Model.Department() { Id = Guid.NewGuid() });

        var handler = new CreateDepartmentRequestHandler(_logger, departmentRepositoryMock.Object);

        //Act 
        var response = await handler.Handle(command, new CancellationToken());


        //Assert
        Assert.True(response.GetType() == typeof(BadRequestObjectResult));
    }

    [Fact]
    public async Task Handle_DepartmentDoesNotExist_ReturnsOk()
    {
        // Arrange
        var command = new CreateDepartmentRequest() { DepartmentType = 0, MaxAcceptableEmployees = 2, SalaryBase = 5000 };

        Department? department = null;
        var departmentRepositoryMock = new Mock<IDepartmentRepository>();
        departmentRepositoryMock.Setup(x => x.GetByTypeAsync(It.IsAny<DepartmentType>()))
            .ReturnsAsync(department);

        var handler = new CreateDepartmentRequestHandler(_logger,departmentRepositoryMock.Object);

        //Act 
        var response = await handler.Handle(command, new CancellationToken());


        //Assert
        Assert.True(response.GetType() == typeof(OkObjectResult));
    }

    [Fact]
    public async Task Handle_AttemptToQueryAgainstDb_ThrowsException()
    {
        // Arrange
        var command = new CreateDepartmentRequest() { DepartmentType = 0, MaxAcceptableEmployees = 2, SalaryBase = 5000 };

        var departmentRepositoryMock = new Mock<IDepartmentRepository>();
        departmentRepositoryMock.Setup(x => x.GetByTypeAsync(It.IsAny<DepartmentType>()))
            .ThrowsAsync(new Exception("ForcedError"));

        var handler = new CreateDepartmentRequestHandler(_logger, departmentRepositoryMock.Object);

        //Act 
        var response = handler.Handle(command, new CancellationToken());


        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await response);
    }
}