using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe refetente aos dados dos emblemas
/// </summary>
public class Emblemas : MonoBehaviour
{
    int id;
    string name, descricao, nameprefab;

    Emblemas(int id, string name, string descricao, string nameprefab){
        this.id = id;
        this.name = name;
        this.descricao = descricao;
        this.nameprefab = nameprefab;
    }
}
