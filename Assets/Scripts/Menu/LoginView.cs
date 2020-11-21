using System;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Classe que fará a manuseio de dados da tela de login para a realização do login
/// </summary>
public class LoginView : Observer
{
    public String serverHOST = "158.69.209.69";//ip servidor no qual que entrar
    public int serverPORT = 8083;
    ServerSender serverSender; //Classe que recebe os dados dessa classe e envia para o código de emissão do servidor
    public GameObject panelLogin; //Próprio painel
    public InputField inputUser,inputSenha;
    public Toggle toggleLocalServer;


    ServerController controlador;//Classe que envia os dados para cá
    
    void Awake(){
        criarObservador();
        serverSender = GameObject.Find("ServerManager").GetComponent<ServerSender>();
        
    }

    /// <summary>
    /// Função que cria o observador do controlador, que emite informações de alteração pra cá (padrão observer)
    /// </summary>
    void criarObservador(){
        try{
            controlador = GameObject.Find("ServerManager").GetComponent<ServerController>();
            controlador.RegisterObserver(this);
        }catch{
            Debug.Log("Erro ao recarregar o ServerController do código LoginView!");
        }

        if(controlador != null){
            controlador.RegisterObserver(this);
        }
    }

    /// <summary>
    /// Função e emite pro servidor a realização de Login
    /// </summary>
    /// <param name="nome">Nickname do usuário</param>
    /// <param name="senha">Senha do usuário</param>
    /// <returns></returns>
    public void logar(){
        string nome = inputUser.text;
        string senha = inputSenha.text;

        if(toggleLocalServer.isOn == true){ //Verifica o toggle para ver se pode logar no servidor central ou não
            serverSender.ConnectServer(nome, senha, "localhost", 3000);
        } else {
            serverSender.ConnectServer(nome, senha, serverHOST, serverPORT);
        }
        
    }

    /// <summary>
    /// Função que desativa a tela de login
    /// </summary>
    public void PainelLoginDisable(){
        panelLogin.SetActive(false);
    }

    /// <summary>
    /// Função que ativa a tela de login
    /// </summary>
    public void PainelLoginEnable(){
        panelLogin.SetActive(true);
        inputUser.text = null;
        inputSenha.text = null;
    }
    

    /// <summary>
    /// Função que recebe a notificação do observador
    /// </summary>
    /// <param name="value">Dado</param>
    /// <param name="notificationType">Tipo de dado (enum)</param>
    public override void OnNotify(object value, NotificationTypes notificationtype){
        if(notificationtype == NotificationTypes.login){ //Quando a notificação de que o usuário foi logado
            PainelLoginDisable();//Desativa o Painel de login
        }
        if(notificationtype == NotificationTypes.loginOut){
            PainelLoginEnable();
        }
    }
}
