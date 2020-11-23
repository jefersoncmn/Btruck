using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por receber informações de entrada do jogo e enviar pra classe de gerenciamento central de recebimento e envio de dados para o servidor (UdpSocketManagerUsage)
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
    /// Função que recebe a notificação do Subject
    /// </summary>
    /// <param name="value">Dado</param>
    /// <param name="notificationType">Tipo de dado (enum)</param>
    public override void OnNotify(object value, NotificationTypes notificationTypes){
        
        if(notificationTypes == NotificationTypes.moviment){
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

    /// <summary>
    /// Faz o envio de dados do usuário para o respectivo servidor
    /// </summary>
    /// <param name="UserName">Nome do usuário</param>
    /// <param name="Password">Senha</param>
    /// <param name="Host">Id do servidor</param>
    /// <param name="Port">Porta do servidor</param>
    public void ConnectServer(string UserName, string Password, string Host, int Port){
        UdpSocketManagerUsage.Instance.ConnectServer(Host,Port,UserName,Password);
    }
}



