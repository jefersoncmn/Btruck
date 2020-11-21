using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por receber informações de entrada do jogo e enviar pro servidor
/// </summary>
public class ServerSender : Observer
{
    public PlayerMovimentController ControladorDeMovimentos;

    void Awake(){
        UdpSocketManagerUsage.Instance = this.gameObject.GetComponent<UdpSocketManagerUsage>();
        registrarObserver();
    }
    void registrarObserver(){
        ControladorDeMovimentos.RegisterObserver(this);
    }

    /// <summary>
    /// Função que recebe a notificação do observador
    /// </summary>
    /// <param name="value">Dado</param>
    /// <param name="notificationType">Tipo de dado (enum)</param>
    public override void OnNotify(object value, NotificationTypes notificationTypes){
        
        if(notificationTypes == NotificationTypes.login){
            sendToServer(value.ToString());
        }
    }

    /// <summary>
    /// Função temporária que envia a informação de qual setinha é pressionada para o servidor
    /// </summary>
    /// <param name="comand">Chave da tecla</param>
    public void sendToServer(string comand){
        UdpSocketManagerUsage.Instance.movimentComands(comand);
    }

    public void ConnectServer(string UserName, string Password, string Host, int Port){
        UdpSocketManagerUsage.Instance.ConnectServer(Host,Port,UserName,Password);
    }
}



