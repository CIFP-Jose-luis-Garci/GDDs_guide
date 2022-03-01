using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;// Required when using Event data.


public class Listeners : MonoBehaviour, ISelectHandler
{
    //Empty que contiene los sliders de sonido
    GameObject VolumeMenu;

    private void Awake()
    {
        VolumeMenu = GameObject.Find("MenuVolume");
    }
    //Listeners
    public void OnSelect(BaseEventData eventData)
    {
        string nombreBtn = this.gameObject.name;
        Debug.Log("Se ha seleccionado el boton: " + nombreBtn);
        //Dependiendo del nombre, o el tag, podemos tomar decisiones
        if(nombreBtn == "Btn_Volume")
        {
            //Accedemos al objeto que contiene los sliders de volumen y lo desactivamos
            
            VolumeMenu.SetActive(true);
        }
        else
        {
            VolumeMenu.SetActive(false);
        }
    }
}
