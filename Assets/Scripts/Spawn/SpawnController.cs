using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pelo manuseio dos spawn points e o instanciamento dos usuários
/// </summary>
public class SpawnController : MonoBehaviour
{
    [SerializeField]
    List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    /// <summary>
    /// Lista com os players que foram instanciados
    /// </summary>
    [SerializeField]
    List<Player> playersInstanciados = new List<Player>();


    /// <summary>
    /// Lista com os GameObject's dos usuários
    /// </summary>
    [SerializeField]
    List<GameObject> GameObjectsPlayers = new List<GameObject>();

    

    /// <summary>
    /// Função que irá instanciar o usuário e seu GameObject do veículo que selecionou, também armazenará sua instancia em uma lista de usuários que foram instanciados.
    /// </summary>
    /// <param name="player">Classe do usuário que será instanciado</param>
    /// <param name="spawnPoint">SpawnPoint que será instanciado o usuário</param>
    public void InstantiatePlayers(Player player, SpawnPoint spawnPoint){
        Vehicle v = player.getSelectedVehicle();
        playersInstanciados.Add(player);
        GameObject go = Instantiate(v.getVehiclePrefab(), spawnPoint.getPosition(), Quaternion.identity);
        GameObjectsPlayers.Add(go);
    }

    /// <summary>
    /// Função que adicionará a lista de spawnPoints um spawnpoint que será recebido do banco
    /// </summary>
    /// <param name="spawnPoint">Spawnpoint que será recebido do banco de dados</param>
    public void addSpawnPoints(SpawnPoint spawnPoint){
        spawnPoints.Add(spawnPoint);
    }

    public List<GameObject> getAllGameObjectsPlayers(){
        return GameObjectsPlayers;
    }
}
