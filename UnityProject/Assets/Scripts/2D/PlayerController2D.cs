using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Variable que contendrá el Input Controller
    InputController inputController;
    //Vector2 para el movimiento del joystick (o teclas)
    Vector2 playerMove;

    //Rigid Body del personaje
    Rigidbody2D rb;

    float speed = 15f;

    private void Awake()
    {
        inputController = new InputController();

        //Movimientos del personaje
        inputController.Player.Move.performed += ctx => playerMove = ctx.ReadValue<Vector2>();
        inputController.Player.Move.canceled += ctx => playerMove = Vector2.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Cargamos el Rigid Body en la variable
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(playerMove * speed);
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
