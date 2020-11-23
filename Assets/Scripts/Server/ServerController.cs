using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    PlayerOnline,
    PlayerOffline
}

/// <summary>
/// Classe que recebe as mensagens do servidor e comunica os outros componentes do jogo
/// </summary>
public class ServerController : Subject
{
    //public PrincipalPanel principalPanel;//Classe do view do PrincipalPanel

    public static GameStates gameState;//Guarda estado do jogo

    //funções serão armazenadas em um dicionário, onde a método será associado ao comando para não utilizar if's
    public delegate void Processo_Regras();//Ponteiro das funções
    Dictionary<string,Processo_Regras> processo_regras = new  Dictionary<string,Processo_Regras>();
    
    /// <summary>
    /// Função que encapsula funções para operar no delegate
    /// </summary>
    void encapsulaProcessos(){
        //processo_regras.Add("oklogin",Regra_login(Usuario userData));
        //processo_regras.Add("returnUserData",ReturnUserData;
    }
    
    void Awake(){
        UdpSocketManagerUsage.Instance = this.gameObject.GetComponent<UdpSocketManagerUsage>();
        encapsulaProcessos();
    }

    /// <summary>
    /// Função que recebe a mensagem do servidor e direciona nas funções, atráves da chave principal
    /// </summary>
    /// <param name="mensagem">Mensagem do servidor</param>
    public void Listener(string mensagem){
        Debug.Log("Mensagem :"+mensagem+" recebida!");
        string chave = getword(mensagem, 0);
        if(chave == "oklogin"){
            Regra_login(mensagem);
        }
        //Debug.Log(chave);
        //processo_regras[chave]();
        
    }

    /// <summary>
    /// Função que emite a classe responsável pela gestão da tela de login a notificação para desativa-lá
    /// Também faz o envio dos dados do player que vieram do servidor para a view (PrincipalPanel)
    /// </summary>
    public void Regra_login(string userData){
        Debug.Log("Usuário Logado!");
        Notify(userData,NotificationTypes.login);
        UdpSocketManagerUsage.Instance.inicializaHeartBeats();//Inicializa o batimento de coração que identifica se o usuário permanece ativo
        
    }

    /*
    /// <summary>
    /// Função responsável por enviar os dados do usuário para o View
    /// </summary>
    void ReturnUserData(){
        principalPanel.OrganizePrincipalPanel(usuario);
    }
    */

    
    /// <summary>
    /// Função que abre a tela de login ao estado do usuario estiver offline
    /// </summary>
    void RegraStateOffline(){
        Notify(null,NotificationTypes.loginOut);
    }
    
    /// <summary>
    /// Função que realiza a divisão da mensagem do servidor
    /// </summary>
    /// <param name="msg">Mensagem do servidor</param>
    /// <param name="n">Item especifico da chave que será retornado</param>
    /// <returns></returns>
    static public string getword(string msg, int n)
    {

        char spearator = ',';

        string[] strlist = msg.Split(spearator);

        if(strlist[n] == string.Empty)
        {
            return "";
        } else
        {
            return strlist[n];
        }
    }
}
