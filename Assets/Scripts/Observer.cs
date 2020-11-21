using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe Observadorá que irá notificar o Subject
/// </summary>
public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(object value, NotificationTypes notificationTypes);
}

/// <summary>
/// Emissor de alterações
/// </summary>
public abstract class Subject : MonoBehaviour
{
    private List<Observer> _observers = new List<Observer>();//Lista com os observadores

    /// <summary>
    /// Função que registra Observadores na lista de Observadores
    /// </summary>
    /// <param name="observer">Observador que será adicionado a lista</param>
    public void RegisterObserver(Observer observer){
        _observers.Add(observer);
        //Debug.Log("Observador criado!");
    }

    /// <summary>
    /// Função que envia a notificação para todos os observadores da lista de observadores
    /// </summary>
    /// <param name="value">Dado emitido</param>
    /// <param name="notificationType">Tipo de dado</param>
    public void Notify(object value, NotificationTypes notificationTypes){
        foreach(var observer in _observers){//percorre os observadores da lista de observadores
            observer.OnNotify(value,notificationTypes);//
        }
    }
}

