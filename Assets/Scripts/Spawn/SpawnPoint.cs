using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint
{
    string name;
    Vector3 position;

    public SpawnPoint(string name, Vector3 position){
        this.name = name;
        this.position = position;
    }

    public string getName(){
        return name;
    }

    public Vector3 getPosition(){
        return position;
    }
}
