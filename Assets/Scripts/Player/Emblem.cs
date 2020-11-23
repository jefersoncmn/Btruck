using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe refetente aos dados dos emblemas
/// </summary>
public class Emblem : MonoBehaviour
{
    int id;
    string emblemName, description, namePrefab;

    Emblem(int id, string emblemName, string description, string namePrefab){
        this.id = id;
        this.emblemName = emblemName;
        this.description = description;
        this.namePrefab = namePrefab;
    }
}
