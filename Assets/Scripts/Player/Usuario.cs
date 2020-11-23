using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe referente aos dados do usuário
/// </summary>
public class Usuario{
    string name;
    int level;
    string vehicle;
    string delivery;

    public string GetName(){
        return name;
    }

    public int GetLevel(){
        return level;
    }

    public string GetVehicle(){
        return vehicle;
    }

    public string GetDelivery(){
        return delivery;
    }

    Emblem[] emblems;

    public Usuario(string name, int level, string vehicle, string delivery){
        this.name = name;
        this.level = level;
        this.vehicle = vehicle;
        this.delivery = delivery;
        //this.emblems = emblems;
    }

}