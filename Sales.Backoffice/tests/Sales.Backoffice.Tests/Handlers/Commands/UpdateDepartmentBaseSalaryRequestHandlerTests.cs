using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Sales.Backoffice.Application.Handlers.Commands;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;
using Sales.Backoffice.Dto.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Tests.Handlers.Commands;

public class UpdateDepartmentBaseSalaryRequestHandlerTests
{
	private readonly ServiceProvider _serviceProvider;
	private readonly ILogger<UpdateDepartmentBaseSalaryRequestHandler> _logger;

	public UpdateDepartmentBaseSalaryRequestHandlerTests()
	{
		_serviceProvider = new Helpers().GetServiceProvider();
		var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
		_logger = loggerFactory.CreateLogger<UpdateDepartmentBaseSalaryRequestHandler>();
	}

	[Fact]
	public async Task Handle_ValidDepartment_ReturnsSuccess()
	{
		//Arrange 
		var departmentRepositoryMock = new Mock<IDepartmentRepository>();
		departmentRepositoryMock.Setup(x => x.GetByTypeAsync(It.IsAny<DepartmentType>()))
			.ReturnsAsync(new Department() { DepartmentType = DepartmentType.Financial, EmployeeBaseSalary = 10000 });

		var command = new UpdateDepartmentBaseSalaryRequest()
		{
			Salary = 20000,
			Type = DepartmentTypeDto.Financial
		};


		var handler = new UpdateDepartmentBaseSalaryRequestHandler(_logger,
			departmentRepositoryMock.Object);

		//Act
		var response = await handler.Handle(command, new CancellationToken());


		//Assert
		Assert.True(response.GetType() == typeof(OkObjectResult));
	}

	[Fact]
	public async Task Handle_DepartmentDoesNotExist_ReturnsNotFound()
	{
		//Arrange 
		
		Department? department = null;
		var departmentRepositoryMock = new Mock<IDepartmentRepository>();
		departmentRepositoryMock.Setup(x => x.GetByTypeAsync(It.IsAny<DepartmentType>()))
			.ReturnsAsync(department);

		var command = new UpdateDepartmentBaseSalaryRequest()
		{
			Salary = 20000,
			Type = DepartmentTypeDto.Financial
		};


		var handler = new UpdateDepartmentBaseSalaryRequestHandler(_logger,
			departmentRepositoryMock.Object);

		//Act
		var response = await handler.Handle(command, new CancellationToken());


		//Assert
		Assert.True(response.GetType() == typeof(NotFoundObjectResult));
	}
}
