using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCameraFollow : MonoBehaviour
{
    //Accedemos al script de la camara
    CameraFollow2D cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow2D>();
    }

    //Si el jugador cae en la trampa o sale de ella, mandamos un mensaje para que deje de seguirle la cámara
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            cameraFollow.SendMessage("StartStopFollow");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //
        if (other.gameObject.name == "Player")
        {
            cameraFollow.SendMessage("StartStopFollow");
        }
    }
}
