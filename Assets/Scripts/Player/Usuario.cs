using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe referente aos dados do usuário
/// </summary>
public class Usuario{
    string name;
    int level;
    string caminhao;
    string frete;

    public string Getname(){
        return name;
    }

    public int Getlevel(){
        return level;
    }

    public string Getcaminhao(){
        return caminhao;
    }

    public string Getfrete(){
        return frete;
    }

    Emblemas[] emblemas;

    Usuario(string name, int level, string caminhao, string frete, Emblemas[] emblemas){
        this.name = name;
        this.level = level;
        this.caminhao = caminhao;
        this.frete = frete;
        this.emblemas = emblemas;
    }

}