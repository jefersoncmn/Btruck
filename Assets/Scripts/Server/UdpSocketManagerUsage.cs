using System;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Essa classe é responsavel por realizar o recebimento e emissão de mensagens para o Servidor.
/// </summary>
public class UdpSocketManagerUsage : MonoBehaviour {
    public static UdpSocketManagerUsage Instance {get;set;}//Variável que obtem o objeto que essa classe está presente (pode ser visto por todos pois é unica)
    public static bool isActive = false;//Variável que identifica se essa classe está ativa
    private UdpSocketManager _udpSocketManager; //Variável que recebe o código do Gerenciador de Sockets, script principal de conexão, conversão e assuntos gerais
    private bool _isListenPortLogged = false;//Variável que identifica se a porta está logada
    public ServerController servercontroller;//Variável que recebe os dados do servidor e emite pra outras classes
    public string sessao,cliente;

    void Awake(){
        if(Instance == null){ //Identificação para operancia do Singleton
            Instance = this;
            DontDestroyOnLoad(gameObject); //Mantém a instância indestrutível ao mudança de cenas
        }else{
            //Destroy(gameObject); 
        }
    }
    void Start()
    { 
        Application.runInBackground = true;//Codigo Operante em background
    }

    void Update()
    {
        if(_udpSocketManager == null)
        {
            return;
        }

        if (!_udpSocketManager.isInitializationCompleted())
        {
            return;
        }

        if (!_isListenPortLogged)
        {
            //Debug.Log("UdpSocketManager, Ouvido pela porta: " + _udpSocketManager.getListenPort());
            _isListenPortLogged = true;
        }

        //percorre com um vetor de byte a mensagem recebida
        foreach (byte[] recPacket in _udpSocketManager.receive())
        {
            //recolhe a mensagem recebida do servidor que é convertida
            string receivedMsg = Encoding.UTF8.GetString(recPacket);
            //Debug.Log("foi recebido a mensagem do servidor:  " + receivedMsg);
            sessao = getword(receivedMsg, 1);
            cliente = getword(receivedMsg, 2);
            servercontroller.Listener(receivedMsg);

    	    /*
            if (getword(receivedMsg, 0) == "oklogin") //se acordo com a chave inicial da emissão do servidor
            {

                //Debug.Log("Personagem logado!");


            }
            */         
        }
    }

    /// <summary>
    /// Função que envia para o servidor as funções de movimentação base (setinhas)
    /// </summary>
    /// <param name="comando">Chave com a string da tecla pressionada</param>
    public void movimentComands(string comando){
        _udpSocketManager.send(Encoding.UTF8.GetBytes(comando+","+sessao+","+cliente));
    }

    /// <summary>
    /// Função que realiza a conexão com o servidor; E posteriormente envia dos dados para o Login
    /// </summary>
    /// <param name="servidor">Ip do servidor</param>
    /// <param name="port">Porta do servidor</param>
    /// <param name="usuario">Nome do usuário</param>
    /// <param name="senha">Senha do usuário</param>
    public void ConnectServer(String servidor, int port, String usuario, String senha)
    {
        _udpSocketManager = new UdpSocketManager(servidor, port);
        StartCoroutine(_udpSocketManager.initSocket());
        Login(usuario,senha);
        
    }

    /// <summary>
    /// Função que realiza a emissão de dados de Login pra o servidor
    /// </summary>
    /// <param name="usuario">Nome do usuário</param>
    /// <param name="senha">Senha do usuário</param>
    public void Login(String usuario, String senha)
    {
        _udpSocketManager.send(Encoding.UTF8.GetBytes("login,"+usuario+","+senha));
       Debug.Log("Login realizado!");
    }

    /// <summary>
    /// Função que realiza um ciclo infinito de emissão de dados de confirmação de que o usuário ainda continua conectado ao servidor (Batimendo de Coração) 
    /// </summary>
    /// <param name="receivedMsg">Mensagem recebida do servidor que contem informações sobre Sessão e o Id do cliente</param>
    /// <returns></returns>
    IEnumerator heartbeats (string receivedMsg)
    {
        //COMAND+SESSIONID+CLIENTID

        while (true)
        {
            Debug.Log("Batimento..");
            //Chave de Heartbeat (chave, sessão, clientID)
            string beatsMsg = "heartbeat," + getword(receivedMsg, 1) +","+ getword(receivedMsg, 2);

            _udpSocketManager.send(Encoding.UTF8.GetBytes(beatsMsg));

            yield return new WaitForSeconds(1.0f);
        }
        
    }

    public void inicializaHeartBeats(){
        string mensagem = "iniciarBatimento,"+sessao+","+cliente;
        StartCoroutine(heartbeats(mensagem));
        
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
    
    /// <summary>
    /// Função que verifica se essa classe é diferente de nula, se for ele irá fechar as Threads
    /// </summary>
    private void OnDestroy()
    {
        if (_udpSocketManager != null)
        {
            _udpSocketManager.closeSocketThreads();
        }
    }
}
