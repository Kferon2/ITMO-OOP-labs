using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Analyzer : IAnalyzer
{
    public Analyzer()
    {
        FuelStock = new FuelStock();
        FuelStockInfo = new FuelStockInfo();
        FuelStock.RegisterObserver(this);
    }

    private FuelStock FuelStock { get; set; }

    private FuelStockInfo FuelStockInfo { get; set; }

    public void Update(object ob)
    {
        FuelStockInfo = (FuelStockInfo)ob;
    }

    public PathResult FlightAnalyze(Path path, ShipBase ship)
    {
        FuelStock.Market();
        PathResult result = new();
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path), "Path can't be null");
        }

        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Ship can't be null");
        }

        foreach (IArea area in path.Areas)
        {
            double impulseTravelFuel = ship.AreaTravelImpulse(area);
            double jumpTravelFuel = ship.AreaTravelJump(area);
            if (impulseTravelFuel < 0 && jumpTravelFuel < 0)
            {
                result.IsShipVisible = false;
                result.Success = false;
                break;
            }

            if (impulseTravelFuel > 0)
            {
                result.FlightFuel = impulseTravelFuel;
                result.FlightCost = FuelStockInfo.ActivePlasma * impulseTravelFuel;
                foreach (IDamageDealer obstacle in area.Obstacles)
                {
                    ship.AcceptDamage(obstacle);
                    if (!ship.IsShipAlive || !ship.IsCrewAlive)
                    {
                        result.Success = false;
                        result.IsShipAlive = ship.IsShipAlive;
                        result.IsCrewAlive = ship.IsCrewAlive;
                        break;
                    }
                }

                return result;
            }

            result.FlightFuel = jumpTravelFuel;
            result.FlightCost = FuelStockInfo.ActivePlasma * jumpTravelFuel;
            foreach (IDamageDealer obstacle in area.Obstacles)
            {
                ship.AcceptDamage(obstacle);
                if (!ship.IsShipAlive || !ship.IsCrewAlive)
                {
                    result.Success = false;
                    result.IsShipAlive = ship.IsShipAlive;
                    result.IsCrewAlive = ship.IsCrewAlive;
                    break;
                }
            }
        }

        return result;
    }

    public ShipBase? CompareShips(IEnumerable<ShipBase> ships, Path path)
    {
        if (ships == null) return null;
        ShipBase? optimalShip = null;
        double optimalFuel = double.MaxValue;
        double optimalCost = double.MaxValue;
        foreach (ShipBase ship in ships)
        {
            PathResult pathResult = FlightAnalyze(path, ship);
            if (!pathResult.Success) continue;
            if (!(pathResult.FlightFuel < optimalFuel) || !(pathResult.FlightCost < optimalCost)) continue;
            optimalFuel = pathResult.FlightFuel;
            optimalCost = pathResult.FlightCost;
            optimalShip = ship;
        }

        return optimalShip;
    }
}