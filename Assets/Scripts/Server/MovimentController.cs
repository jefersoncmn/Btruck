using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por manusear a movimentação de todos os usuários que estão instanciados
/// </summary>
public class MovimentController : MonoBehaviour
{
    SpawnController spawnController;

    public void Awake(){
        spawnController = GameObject.Find("ServerManager").GetComponent<SpawnController>();
    }

    /// <summary>
    /// Função que irá atualizar o posicionamento dos usuários
    /// </summary>
    public void changePosition(string playerId){

    }

    /*
    public void movimentVehicle(List<WheelCollider> wheelColliders, List<GameObject> rodas){
        Vector3 posicao; 
        Quaternion rotacao;

        for(int i=0; i<wheelColliders.Length; i++){
            
            wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * torque;
            //wheelColliders[i].brakeTorque;
            if(i<2){
                wheelColliders[i].steerAngle = Mathf.Lerp(wheelColliders[i].steerAngle,volante*Input.GetAxis("Horizontal"),Time.deltaTime*10);
            }
            

            wheelColliders[i].GetWorldPose(out posicao, out rotacao);//pega posição dos colisores
            
            rodas[i].position = posicao;
            rodas[i].rotation = rotacao;
            
        }
    }
    */
}
