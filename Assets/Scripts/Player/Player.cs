using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que conterá dados do Jogador
/// </summary>
public class Player : MonoBehaviour
{
    string nameUser;
    double money;
    int level;
    List<Vehicle> vehicles;
    Vehicle selectedVehicle;
    public Player(string nameUser, double money, int level, List<Vehicle> vehicles){
        this.nameUser = nameUser;
        this.money = money;
        this.level = level;
        this.vehicles = vehicles;
    }
    public string getnameUser(){
        return nameUser;
    }
    public void setnameUser(string nameUser){
        this.nameUser = nameUser;
    }
    public double getMoney(){
        return money;
    }
    public void setMoney(double money){
        this.money = money;
    }
    public int getLevel(){
        return level;
    }
    public void setLevel(int level){
        this.level = level;
    }
    public void addVehicle(Vehicle vehicle){
        vehicles.Add(vehicle);
    }
    public List<Vehicle> getAllVehicles(){
        return vehicles;
    } 
    public void setSelectedVehicle(Vehicle vehicle){
        selectedVehicle = vehicle;
    }
    public Vehicle getSelectedVehicle(){
        return selectedVehicle;
    }
}
