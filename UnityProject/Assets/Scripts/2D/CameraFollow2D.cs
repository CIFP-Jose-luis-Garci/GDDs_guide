using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    //Booleana que hará que se siga al jugador o no
    private bool siguiendo = true;

    //Posición del jugador
    [SerializeField] Transform playerPosition;
    //Vector3 al que apuntará la cámara
    Vector3 targetPosition;

    //Variables  necesarias  para  la  opción  de  suavizado
    [SerializeField]
    float smoothVelocity = 0.2F;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;

    //El seguimiento de la cámara se hace en FixedUpdate porque el personaje se mueve por físicas
    void FixedUpdate()
    {

         Follow();

    }

    //Método para seguir al jugador
    void Follow()
    {

        //Si le estoy siguiendo, actualizo la posición, si no, se quedará con la que tenga (la del jugador en ese momento)
        if(siguiendo)
        {
            
            targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
        }
        //Con  este  código,  conseguimos  que  siga  al  objeto  pero  con  suavidad 
        //La  velocidad  de  suavizado,  cuanto  menor  sea  más  brusco  será  el  movimiento
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
    }

    //Método público que hará que cambie el seguimiento o no
    public void StartStopFollow()
    {
        //Es un interruptor: si está siguiendo, para, y si no, empieza
        if(siguiendo)
        {
            siguiendo = false;
        }
        else
        {
            siguiendo = true;
        }
    }
}
