using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTests
{
    [Theory]
    [InlineData(50)]
    [InlineData(40)]
    [InlineData(60)]
    public void FirstTestCase(int pathLength)
    {
        var analyzer = new Analyzer();
        ShipBase satellite = new ShipFactory().PleasureShuttle();
        ShipBase augur = new ShipFactory().Augur();
        var area = new AreaHighDensityNebula(pathLength, new List<ObstacleAntimatterFlash>());
        var path = new Path(new List<IArea> { area });

        PathResult satelliteResult = analyzer.FlightAnalyze(path, satellite);
        PathResult augurResult = analyzer.FlightAnalyze(path, augur);

        Assert.False(satelliteResult.Success);
        Assert.False(augurResult.Success);
        Assert.False(augurResult.IsShipVisible);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void SecondTestCase(int pathLength)
    {
        var shipFactory = new ShipFactory();
        var analyzer = new Analyzer();
        ShipBase vaklasBasic = shipFactory.Vaklas();
        ShipBase vaklasPhoton = shipFactory.ModifyDeflectorPhoton(shipFactory.Vaklas());
        var area = new AreaHighDensityNebula(pathLength, new List<ObstacleAntimatterFlash> { new(1, 1) });
        var path = new Path(new List<IArea> { area });

        PathResult vaklasBasicResult = analyzer.FlightAnalyze(path, vaklasBasic);
        PathResult vaklasPhotonResult = analyzer.FlightAnalyze(path, vaklasPhoton);

        Assert.False(vaklasBasicResult.Success);
        Assert.False(vaklasBasicResult.IsCrewAlive);
        Assert.True(vaklasPhotonResult.Success);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    public void ThirdTestCase(int pathLength)
    {
        var analyzer = new Analyzer();
        var shipFactory = new ShipFactory();
        ShipBase vaklas = shipFactory.Vaklas();
        ShipBase augur = shipFactory.Augur();
        ShipBase meridian = shipFactory.Meridian();
        var vaklasPath = new Path(new List<IArea>
            { new AreaNitrineNebula(pathLength, new List<ObstacleCosmoWhale> { new(1) }) });
        var augurPath = new Path(new List<IArea>
            { new AreaNitrineNebula(pathLength, new List<ObstacleCosmoWhale> { new(1) }) });
        var maridianPath = new Path(new List<IArea>
            { new AreaNitrineNebula(pathLength, new List<ObstacleCosmoWhale> { new(1) }) });

        PathResult vaklasResult = analyzer.FlightAnalyze(vaklasPath, vaklas);
        PathResult augurResult = analyzer.FlightAnalyze(augurPath, augur);
        PathResult meridianResult = analyzer.FlightAnalyze(maridianPath, meridian);

        Assert.False(vaklasResult.Success);
        Assert.False(vaklasResult.IsShipAlive);
        Assert.True(augurResult.Success);
        Assert.True(augurResult.IsShipAlive);
        Assert.True(augur.Deflector != null && !augur.Deflector.IsAlive);
        Assert.True(meridianResult.Success);
        Assert.True(meridianResult.IsShipAlive);
        Assert.False(meridian.Emitter != null && meridian.Emitter.IsAlive);
    }

    [Fact]
    public void FourthTestCase()
    {
        var analyzer = new Analyzer();
        var shipFactory = new ShipFactory();
        var area = new AreaCosmos(10, new List<ObstaclePhysical>());
        var path = new Path(new List<IArea> { area });
        ShipBase shuttle = shipFactory.PleasureShuttle();
        ShipBase vaklas = shipFactory.Vaklas();

        PathResult shuttleResult = analyzer.FlightAnalyze(path, shuttle);
        PathResult vaklasResult = analyzer.FlightAnalyze(path, vaklas);

        Assert.True(shuttleResult.Success);
        Assert.True(vaklasResult.Success);
        Assert.True(shuttleResult.FlightFuel < vaklasResult.FlightFuel);
    }

    [Fact]
    public void FifthTestCase()
    {
        var analyzer = new Analyzer();
        var shipFactory = new ShipFactory();
        var area = new AreaHighDensityNebula(20, new List<ObstacleAntimatterFlash>());
        var path = new Path(new List<IArea> { area });
        ShipBase augur = shipFactory.Augur();
        ShipBase stella = shipFactory.Stella();

        Assert.Equal(analyzer.CompareShips(new List<ShipBase> { augur, stella }, path), stella);
    }

    [Fact]
    public void SixthTestCase()
    {
        var analyzer = new Analyzer();
        var shipFactory = new ShipFactory();
        var area = new AreaNitrineNebula(10, new List<ObstacleCosmoWhale>());
        var path = new Path(new List<IArea> { area });
        ShipBase shuttle = shipFactory.PleasureShuttle();
        ShipBase vaklas = shipFactory.Vaklas();

        Assert.Equal(analyzer.CompareShips(new List<ShipBase> { vaklas, shuttle }, path), vaklas);
    }

    [Fact]
    public void SeventhTestCase()
    {
        var analyzer = new Analyzer();
        var shipFactory = new ShipFactory();
        var area = new AreaHighDensityNebula(5, new List<ObstacleAntimatterFlash>());
        var path = new Path(new List<IArea> { area });
        ShipBase augur = shipFactory.Augur();
        ShipBase stella = shipFactory.Stella();
        ShipBase shuttle = shipFactory.PleasureShuttle();
        ShipBase vaklas = shipFactory.Vaklas();

        Assert.Equal(analyzer.CompareShips(new List<ShipBase> { augur, stella, shuttle, vaklas }, path), vaklas);
    }
}