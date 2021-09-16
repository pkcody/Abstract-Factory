using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// there is a different style in woodfine, but both work
public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

// in Woodfine (more cases than slease's)
public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            case 2:
                return new Tandem();
            case 3:
                return new Tricycle();
            case 4:
                if (requirements.HasCargo) return new GoKart();
                return new FamilyBike();
            default:
                return new Bicycle();
        }
    }
}

// (not woodfine)
public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 4) return new Car();
                return new Motorbike();
            default:
                return new Truck();
        }
    }
}

public abstract class AbstractVehicleFactory
{
    //public abstract IVehicleFactory CycleFactory();
    //public abstract IVehicleFactory MotorVehicleFactory();

    public abstract IVehicle Create();
}

public class VehicleFactory : AbstractVehicleFactory
{
    /*public override IVehicleFactory CycleFactory()
    {
        return new Cyclefactory();
    }

    public override IVehicleFactory MotorVehicleFactory()
    {
        return new MotorVehicleFactory();
    }*/

    // Woodfine

    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        _factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new CycleFactory();
        _requirements = requirements;
    }

    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }

}