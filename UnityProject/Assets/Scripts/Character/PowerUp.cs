using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //Interruptor
    bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Interruptor para que se ejecute una vez
        if(!hit)
        {
            GameManager.globalScore++;
            hit = true;
        }

        Destroy(gameObject);
            

    }
}
