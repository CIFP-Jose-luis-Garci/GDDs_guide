using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Exit : MonoBehaviour
{
    //Obtenemos el menu que queremos desactivar/activar
    //Es un Empty Object que actua como padre de los elementos
    [SerializeField] GameObject resumeMenu;

    //Texto del contador que nos permite ver cómo se pausa el juego
    [SerializeField] Text contador;
    int contadorNum = 0;

    //Booleana que nos dice si el juego está pausado o no
    bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el menú mediante código (en vez de arrastrarlo)
        //IMPORTANTE: Cambiar el nombre del gameobject por el vuestro
        resumeMenu = GameObject.Find("MenuPause");

        //Lo desactivamos de inicio
        resumeMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Método que ejecutamos constantemente
        // Podemos cambiarlo por ejemplo por el movimiento de nuestro personaje
        Contador();

        //Si pulsamos la tecla "Esc" o la que sea, se activa el menú
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ActivarMenu();
        }

    }

    
    void ActivarMenu()
    {
        //Interruptor que permite activar y desactivar un menú
        //Si no está pausado, lo pausamos
        if(!gamePaused)
        {
            gamePaused = true;
            //Detenemos el tiempo del juego
            Time.timeScale = 0f;
        }
        else
        {
            gamePaused = false;
            //Devolvemos el paso del tiempo al juego
            Time.timeScale = 1f;
        }
        //Lo que haya salido de este interruptor, lo pasamos al menú para que se active o no
        resumeMenu.SetActive(gamePaused);
    }

    void Contador()
    {

        //Si el juego está pausado, detenemos el método mediante un return
        //NOTA: cuando un IF solo tiene una línea, no es necesario llaves
        if (gamePaused)
            return;

        //Vamos aumentando el contador
        contadorNum++;
        contador.text = contadorNum.ToString();

    }

    //FUNCIONES PARA LOS BOTONES
    public void Resume()
    {
        //DESpausamos el juego y ocultamos el menú
        gamePaused = false;
        Time.timeScale = 1f;
        resumeMenu.SetActive(false);
        
    }

    public void Salir()
    {
        //Esta línea de código hace que se salga del juego
        //ES MUY IMPORTANTE DAR A LOS JUGADORES LA OPCiÓN DE SALIR
        //En lugar de apagar el programa, cargo la escena de créditos
        SceneManager.LoadScene(2);
    }
}
