using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerMovimentController : Subject
{
    //funções de movimento serão armazenadas em um dicionário, onde a método será associado ao comando para não utilizar if's
    public delegate void Moviment_Rules();
    Dictionary<string,Moviment_Rules> moviment_Rules = new  Dictionary<string,Moviment_Rules>();
    
    /// <summary>
    /// Função responsável por receber os inputs
    /// </summary>
    public void Input_Control_Moviment(){
    
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                try{
                    string key = ""+vKey;
                    moviment_Rules[key]();
                }catch{
                    
                } 
            }
        }
    }

    public void Moviment_Forward(){
        
        Notify("Forward", NotificationTypes.moviment);
        //print("Frente");
    }

    public void Moviment_Left(){
        
        Notify("Left", NotificationTypes.moviment);
    }
    public void Moviment_Right(){
        
        Notify("Right", NotificationTypes.moviment);
    }
    public void Moviment_Down(){
        
        Notify("Down", NotificationTypes.moviment);
    }

    public void FixedUpdate(){
        Input_Control_Moviment();
    }

    public void Awake(){
        
        moviment_Rules.Add("UpArrow",Moviment_Forward);
        moviment_Rules.Add("LeftArrow",Moviment_Left);
        moviment_Rules.Add("DownArrow",Moviment_Down);
        moviment_Rules.Add("RightArrow",Moviment_Right);
    }

    
}
