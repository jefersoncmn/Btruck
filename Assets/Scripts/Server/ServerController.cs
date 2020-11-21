using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que recebe as mensagens do servidor e comunica os outros componentes do jogo
/// </summary>
public class ServerController : Subject
{
    public PrincipalPanel principalPanel;//Classe do view do PrincipalPanel

    //funções serão armazenadas em um dicionário, onde a método será associado ao comando para não utilizar if's
    public delegate void Processo_Regras();//Ponteiro das funções
    Dictionary<string,Processo_Regras> processo_regras = new  Dictionary<string,Processo_Regras>();
    
    /// <summary>
    /// Função que encapsula funções para operar no delegate
    /// </summary>
    void encapsulaProcessos(){
        processo_regras.Add("oklogin",Regra_login);
        processo_regras.Add("returnUserData",ReturnUserData);
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
        //Debug.Log(chave);
        processo_regras[chave]();
        
    }

    /// <summary>
    /// Função que emite a classe responsável pela gestão da tela de login a notificação para desativa-lá
    /// </summary>
    void Regra_login(){
        //Debug.Log("Usuário Logado!");
        Notify(null,NotificationTypes.login);
        UdpSocketManagerUsage.Instance.inicializaHeartBeats();//Inicializa o batimento de coração que identifica se o usuário permanece ativo
    }

    /// <summary>
    /// Função responsável por enviar os dados do usuário para o View
    /// </summary>
    void ReturnUserData(){
        //principalPanel.OrganizePrincipalPanel(usuario);
    }
    
    
    /// <summary>
    /// Função que realiza a divisão da mensagem do servidor
    /// </summary>
    /// <param name="msg">Mensagem do servidor</param>
    /// <param name="n">Item especifico da chave que será retornado</param>
    /// <returns></returns>
    public string getword(string msg, int n)
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
