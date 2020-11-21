using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe responsável pelo manuseio de dados da tela principal do usuário.
/// Apresenta os dados do usuário e possibilita a entrada no mapa.
/// </summary>
public class PrincipalPanel : Observer
{
    public GameObject panelPrincipal;
    
    ServerController controlador;//Classe que envia os dados de comportamento de estado para cá

    public Text nomeUsuario, nomeCaminhao, level, frete;//Textos com dados que são apresentados para o usuário
    void Start(){
        criarObservador();
    }

    /// <summary>
    /// Função que cria o observador no controlador
    /// </summary>
    void criarObservador(){

        try{
            controlador = GameObject.Find("ServerManager").GetComponent<ServerController>();
            controlador.RegisterObserver(this);
        }catch{
            Debug.Log("Erro ao recarregar o ServerController do código PrincipalPanel!");
        }

        if(controlador != null){
            controlador.RegisterObserver(this);
        }
    }


    /// <summary>
    /// Função que ativa a tela principal
    /// </summary>
    public void PanelPrincipalEnabled(){
        panelPrincipal.SetActive(true);
    }

    /// <summary>
    /// Função que recebe a notificação do observador
    /// </summary>
    /// <param name="value">Dado</param>
    /// <param name="notificationType">Tipo de dado (enum)</param>
    public override void OnNotify(object value, NotificationTypes notificationTypes){
        
        if(notificationTypes == NotificationTypes.login){ //Caso o login seja realizado com sucesso
            PanelPrincipalEnabled();//O PainelPrincipal é ativado
        }
    }


    /// <summary>
    /// Função que irá colocar os dados do usuário recebidos pelo servidor no PainelPrincipal
    /// </summary>
    /// <param name="usuario">Dados do usuário</param>
    public void OrganizePrincipalPanel(Usuario usuario){
        nomeCaminhao.text = usuario.Getcaminhao();
        nomeUsuario.text = usuario.Getname();
        level.text = usuario.Getlevel().ToString();
        frete.text = usuario.Getfrete();
    }
}





