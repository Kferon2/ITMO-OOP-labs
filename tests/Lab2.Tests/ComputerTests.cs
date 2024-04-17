using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerTests
{
    private StorageRepository _storage = new TestDataBase().Storage;

    [Fact]
    public void FirstTestCase()
    {
        // Arrange
        Config config = new TestDataBase().FirstTestConfig;
        var validator = new ComputerValidator();
        var builder = new ComputerBuilder();

        // Act
        Computer.Computer computer = new ComputerDirector().CreateComputer(_storage, config, builder);

        // Assert
        Assert.True(validator.Validate(computer).IsValid);
    }

    [Fact]
    public void SecondTestCase()
    {
        // Arrange
        Config config = new TestDataBase().SecondTestConfig;
        var validator = new ComputerValidator();
        var builder = new ComputerBuilder();

        // Act
        Computer.Computer computer = new ComputerDirector().CreateComputer(_storage, config, builder);

        // Assert
        Assert.True(validator.Validate(computer).IsValid);
    }

    [Fact]
    public void ThirdTestCase()
    {
        // Arrange
        Config config = new TestDataBase().ThirdTestConfig;
        var validator = new ComputerValidator();
        var builder = new ComputerBuilder();

        // Act
        Computer.Computer computer = new ComputerDirector().CreateComputer(_storage, config, builder);

        // Assert
        Assert.True(validator.Validate(computer).IsValid);
    }

    [Fact]
    public void FourthTestCase()
    {
        // Arrange
        Config config = new TestDataBase().FourthTestConfig;
        var validator = new ComputerValidator();
        var builder = new ComputerBuilder();

        // Act
        Computer.Computer computer = new ComputerDirector().CreateComputer(_storage, config, builder);

        // Assert
        Assert.False(validator.Validate(computer).IsValid);
    }
}