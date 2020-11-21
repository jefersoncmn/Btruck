using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pelo giro das rodas
/// </summary>
public class rotacaoRodas : MonoBehaviour
{

    public WheelCollider[] wheelColliders; //colisores das rodas
    public Transform[] rodas;//objetos das rodas

    public float torque,volante;

    /// <summary>
    /// Função que atualiza o giro das rodas com os colisores
    /// </summary>
    void updateRodas(){
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
    

    void Update(){
        //updateRodas();
    }
}
