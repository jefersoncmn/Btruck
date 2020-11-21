using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Essa classe é responsável pela contrução dos botões dos respectivos servidores.
Ela tem as funções:

- void AdicionarLista_Servers(string nome, estadosServer estado, int players, int playersLimit)
Função responsável por adicionar a lista de servidores (texto do nome do servidor, estado do servidor (On/Off), quantidade de pessoas nele, limite de pessoas)

- GameObject Criar_Botao_Servidor(GameObject card, string nome, estadosServer estado, int players, int playersLimit)
Função responsável por fazer todas as alterações no botão relacionadas as informações do servidor

*/
public class ScrollViewController_Server : MonoBehaviour
{
    //Variavel que armazena o componente do Scroll View
    public GameObject scrollView;

    //Variavel que armazena o botão que será instanciado dentro da Scroll View
    public Button button;

    //Variaveis de estado do servidor
    public enum estadosServer{Online,Offline};

    /// <summary>
    /// Função responsável por adicionar a lista de servidores
    /// </summary>
    /// <param name="nome">texto do nome do servidor</param>
    /// <param name="estado">estado do servidor</param>
    /// <param name="players">quantidade de pessoas nele</param>
    /// <param name="playersLimit">limite de pessoas</param>
    public void AdicionarLista_Servers(string nome, estadosServer estado, int players, int playersLimit){
        //Cria um objeto que receberá o button instanciado
        GameObject card = Instantiate(button.gameObject) as GameObject;
        card = Criar_Botao_Servidor(card, nome, estado, players, playersLimit);
 
        //Verifica a existentia do Scroll View para definir como parente
        if (scrollView.gameObject != null){
            //Pega o viewPort dentro do scrollView
            GameObject viewPort = scrollView.transform.Find("Viewport/Content").gameObject;
            //Seta o ScrollView como pai
            card.transform.SetParent(viewPort.transform,false);
        }

        
    }

    /// <summary>
    /// Faz todas as alterações no botão do respectivo servidor
    /// </summary>
    /// <param name="card"></param>
    /// <param name="nome">Nome do servidor</param>
    /// <param name="estado">Estado do servidor</param>
    /// <param name="players">Quantidade de usuários jogando</param>
    /// <param name="playersLimit">Limite de usuário no servidor</param>
    /// <returns></returns>
    public GameObject Criar_Botao_Servidor(GameObject card, string nome, estadosServer estado, int players, int playersLimit){
        //Coloca o nome do servidor no botão
        Text texto = card.transform.Find("Text-Name").GetComponentInChildren<Text>();
        texto.text = nome;

        //Coloca o estado do servidor no botão
        texto = card.transform.Find("Text-State").GetComponentInChildren<Text>();
        texto.text = estado.ToString();
        //Mudar a cor do texto do estado do servidor de acordo com o estado
        if(estado == estadosServer.Online){
            texto.color = Color.green;
        } else {
            texto.color = Color.red;
        }
        
        //Coloca a quantidade de players no servidor e limite, no botão
        texto = card.transform.Find("Text-Players").GetComponentInChildren<Text>();
        texto.text = players.ToString()+"/"+playersLimit.ToString();
        
        return card;
    }
    public void Start(){
        
        AdicionarLista_Servers("Server America 1", estadosServer.Online, 12, 50);
    }
}


