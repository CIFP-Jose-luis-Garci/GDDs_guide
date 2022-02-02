using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    //Valores para el desplazaamiento
    float desplX;
    float desplY;
    float speed = 2f;

    float jumpHeight = 2.0f;
    float gravityValue = -9.81f;

    //Vector para el deplazamiento
    Vector3 despl;

    //Componente Character Controller
    CharacterController cc;

    //ROTACIÓN CON CINEMACHINE
    //Cámara que nos permitirá girar al personaje
    [SerializeField] Camera freeCamera;
    //Valores para la rotación (suavizado y velocidad)
    float turnSmoothTime = 0.2f;
    float turnSmoothVelocity = 30f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Mover();

        Saltar();

        Rotar();
    }

    void Saltar()
    {
        //Si el personaje está tocando suelo pero sigue cayendo, lo paramos
        if (cc.isGrounded && despl.y < 0)
        {
            despl.y = 0f;
        }

        //Si pulsamos el botón de saltar y está tocando suelo
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            //Aplicamos un empuje hacia arriba en el vector de desplazamiento
            despl.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        despl.y += gravityValue * Time.deltaTime;
        cc.Move(despl * Time.deltaTime);
    }




    void Mover()
    {
        desplX = Input.GetAxis("Horizontal");
        desplY = Input.GetAxis("Vertical");

        //Siempre andará hacia adelante
        Vector3 despl = transform.forward;

        cc.SimpleMove(despl * speed * desplY);

        Vector3 move = new Vector3(desplX, 0, desplY);
        //controller.Move(move * Time.deltaTime * playerSpeed);


        //Giro
        //Vector3 turn = new Vector3(0f, 1f, 0f);
        //transform.Rotate(turn * desplX);
    }

    void Rotar()
    {
        //Obtenemos el ángulo de la cámara
        float targetAngle = Mathf.Atan2(despl.x, despl.z) * Mathf.Rad2Deg + freeCamera.transform.eulerAngles.y;
        //Obtenemos el ángulo al que tendríamos que mirar nosotros
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //Giramos al personaje
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

    }
}
