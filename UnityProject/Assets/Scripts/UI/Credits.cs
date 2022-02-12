using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] Text tit;
    [SerializeField] Text subt;
    [SerializeField] string[] titulos;
    [SerializeField] string[] subtitulos;
    [SerializeField] float intervalo;
    int clave; //puntero del array que pondremos

    // called zero
    void Awake()
    {
        Debug.Log("Awake");
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // Start is called before the first frame update
    void Start()
    {
        //IMPORTANTE: como vengo de una pausa, tengo que restablecer el tiempo
        Time.timeScale = 1;

        //Intervalo para los títulos
        intervalo = 4f;

        //Limpio los textos
        tit.text = "";
        subt.text = "";

        //Espero 2 segundos e inicio la corrutina que cambia los créditos
        Invoke("ComenzarCreditos", 2f);
    }

    void ComenzarCreditos()
    {
        StartCoroutine("CambioDeCreditos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CambioDeCreditos()
    {
        for(int n = 0; n <= titulos.Length; n++)
        {
            //print(n);
            //Si he llegado al último título, salgo de la aplicación
            if (n == titulos.Length)
            {
                tit.text = "";
                subt.text = "GRACIAS";
                Application.Quit();
            }
            else
            {
                tit.text = titulos[n];
                subt.text = subtitulos[n];
            }

            yield return new WaitForSeconds(intervalo);
            //Si he llegado al último, cierro la aplicación
            
            
        }
        
    }
}
