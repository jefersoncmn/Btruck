using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Classe responsável por carregar os prefabs de veículos do jogo
/// </summary>
public class VehiclesLoader : MonoBehaviour
{
    public List<GameObject> vehicles;
    void Start(){
        vehicles = LoadVehicles();
    }

    /// <summary>
    /// Função que pegará os GameObject's dos veículos da pasta Vehicles
    /// </summary>
    /// <returns>Retornará a lista com os GameObject's com os veículos</returns>
    public List<GameObject> LoadVehicles(){
        List<GameObject> vc = new List<GameObject>();
        string[] namesFiles = FileName.GetFilesNames("Assets/Resources/Prefabs/Vehicles",".prefab").ToArray();
        
        for(int i=0; i<namesFiles.Length;i++){
            vc.Add(Resources.Load<GameObject>("Prefabs/Vehicles/"+namesFiles[i]));
            
        }
        return vc;
        
    }

    /// <summary>
    /// Função que retorna o GameObject do veiculo
    /// </summary>
    /// <param name="nameVehiclePrefab">Name do GameObject do veículo</param>
    /// <returns>GameObject do veículo</returns>
    public static GameObject returnSpecifiedVehicle(string nameVehiclePrefab){
        GameObject go;
        go = Resources.Load<GameObject>("Prefabs/Vehicles/"+nameVehiclePrefab); 
        return go;
    }
}
