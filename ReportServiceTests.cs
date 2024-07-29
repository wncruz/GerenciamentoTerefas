using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MyApp.Models;
using MyApp.Repositories;
using MyApp.Services;
using Xunit;

public class ReportServiceTests
{
    private readonly Mock<IReportRepository> _mockRepo;
    private readonly ReportService _service;

    public ReportServiceTests()
    {
        _mockRepo = new Mock<IReportRepository>();
        _service = new ReportService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAverageCompletedTasksAsync_ShouldReturnCorrectAverage()
    {
        // Arrange
        var expectedData = new List<UserTaskCompletion>
        {
            new UserTaskCompletion { UserId = 1, UserName = "User1", AverageCompletedTasks = 1.5 },
            new UserTaskCompletion { UserId = 2, UserName = "User2", AverageCompletedTasks = 2.0 }
        };
        _mockRepo.Setup(repo => repo.GetAverageCompletedTasksAsync()).ReturnsAsync(expectedData);

        // Act
        var result = await _service.GetAverageCompletedTasksAsync();

        // Assert
        Assert.Equal(expectedData.Count, result.Count);
        Assert.Equal(expectedData[0].AverageCompletedTasks, result[0].AverageCompletedTasks);
        Assert.Equal(expectedData[1].AverageCompletedTasks, result[1].AverageCompletedTasks);
    }

    // Adicione mais testes para cobrir outras regras de negócio
}
