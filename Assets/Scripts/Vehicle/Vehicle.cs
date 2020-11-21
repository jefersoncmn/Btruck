using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    string nameVehicle;
    GameObject vehiclePrefab;

    /// <summary>
    /// Função de criação de veiculos
    /// </summary>
    /// <param name="nameVehicle">Nome do veículo</param>
    /// <param name="nameVehiclePrefab">Nome da prefab do veículo</param>
    public Vehicle(string nameVehicle, string nameVehiclePrefab){
        this.nameVehicle = nameVehicle;
        vehiclePrefab = VehiclesLoader.returnSpecifiedVehicle(nameVehiclePrefab);
    }

    public string getNameVehicle(){
        return nameVehicle;
    }
    public void setNameVehicle(string nameVehicle){
        this.nameVehicle = nameVehicle;
    }
    public GameObject getVehiclePrefab(){
        return vehiclePrefab;
    }
    public void setVehiclePrefab(GameObject vehiclePrefab){
        this.vehiclePrefab = vehiclePrefab;
    }

}
