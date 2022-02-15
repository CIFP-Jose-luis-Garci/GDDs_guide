using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    //Instancia del Input System
    InputController inputController;

    //Valores para el desplazaamiento
    float desplX;
    float desplY;
    Vector2 stickL;
    float strafe;
    Vector3 dir;

    float speed = 2f;
    bool corriendo = false;

    //Salto
    float jumpHeight = 1.0f;
    float gravityValue = -9.81f;
    bool saltando = false;
    Vector3 dirJump;

    //Dash 
    float _dashTime = 1f;
    float _dashSpeed = 7f;

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

    private void Awake()
    {
        inputController = new InputController();

        //Botón de correr
        inputController.Player.Run.performed += ctx => { corriendo = true; };
        inputController.Player.Run.canceled += ctx => { corriendo = false; };

        //Stick para caminar
        inputController.Player.Move.performed += ctx => stickL = ctx.ReadValue<Vector2>();
        inputController.Player.Move.canceled += _ => stickL = Vector2.zero;

        //Triggers
        inputController.Player.Strafe.performed += ctx => strafe = ctx.ReadValue<float>();
        inputController.Player.Strafe.canceled += ctx => strafe = 0f;


        //Dash
        inputController.Player.Dash.performed += _ => Dash();


        //Saltar
        inputController.Player.Jump.started += _ => { saltando = true; };

    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Caminar();

        Rotar();

 
    }

    void Caminar()
    {
        
        if(corriendo && stickL.y > 0)
        {
            speed = 6;
        }
        else if (stickL.y > 0)
        {
            speed = 2.2f;
        }
        else if (stickL.y < 0)
        {
            speed = 0.8f;
        }
        else
        {
            speed = 0f;
        }

        //Si está tocando suelo y se mueve hacia abajo, lo paramos
        if (cc.isGrounded && dirJump.y < 0)
        {
            dirJump.y = 0f;
        }

        //Vector para caminar siempre hacia adelante
        dir = transform.TransformDirection(Vector3.forward);
        //Si pulsamos el botón de saltar y está tocando suelo
        if (saltando && cc.isGrounded)
        {
            //Aplicamos un empuje hacia arriba en el vector de desplazamiento del salto

            dirJump.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //Lo ponemos en false para que este IF se ejecute solo una vez
            saltando = false;
            //cc.Move(dirJump * Time.deltaTime);
        }
        //Hacemos que la caída sea suave
        dirJump.y += gravityValue * Time.deltaTime;
        //El vector de movimiento final será el de hacia adelante más el del salto
        Vector3 dirFinal = (dir * speed * stickL.y) + dirJump;
        cc.Move(dirFinal * Time.deltaTime);
        




    }

    //Dash
    void Dash()
    {
        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        while (Time.time < startTime + _dashTime)
        {
            //transform.Translate(transform.forward * _dashSpeed * Time.deltaTime);

            cc.Move(transform.forward * _dashSpeed * Time.deltaTime);
            // or controller.Move(...), dunno about that script
            yield return null; // this will make Unity stop here and continue next frame
        }
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

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }
}
