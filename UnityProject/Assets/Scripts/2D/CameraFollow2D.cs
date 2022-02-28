using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    //Booleana que har� que se siga al jugador o no
    private bool siguiendo = true;

    //Posici�n del jugador
    [SerializeField] Transform playerPosition;
    //Vector3 al que apuntar� la c�mara
    Vector3 targetPosition;

    //Variables  necesarias  para  la  opci�n  de  suavizado
    [SerializeField]
    float smoothVelocity = 0.2F;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;

    //El seguimiento de la c�mara se hace en FixedUpdate porque el personaje se mueve por f�sicas
    void FixedUpdate()
    {

         Follow();

    }

    //M�todo para seguir al jugador
    void Follow()
    {

        //Si le estoy siguiendo, actualizo la posici�n, si no, se quedar� con la que tenga (la del jugador en ese momento)
        if(siguiendo)
        {
            
            targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
        }
        //Con  este  c�digo,  conseguimos  que  siga  al  objeto  pero  con  suavidad 
        //La  velocidad  de  suavizado,  cuanto  menor  sea  m�s  brusco  ser�  el  movimiento
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
    }

    //M�todo p�blico que har� que cambie el seguimiento o no
    public void StartStopFollow()
    {
        //Es un interruptor: si est� siguiendo, para, y si no, empieza
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
