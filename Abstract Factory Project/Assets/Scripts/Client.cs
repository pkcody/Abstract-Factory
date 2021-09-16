using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    void Start()
    {
        // sleases checking
        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        // in woodfine but added engine
        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        //IVehicle v = new Unicycle();
        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);
    }

    // woodfines but changed
    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        /* var factory = new VehicleFactory();
         IVehicle vehicle;

         if (requirements.HasEngine)
         {
             return factory.MotorVehicleFactory().Create(requirements);
         } 

        return factory.CycleFactory().Create(requirements);*/

        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();

    }

}    
