using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    private static Contador instance;
    public static Contador Instance { get { return instance; } }

    private float tiempoRestante;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        tiempoRestante = 30f;
    }
    void Update()
    {
        
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
        }
        else
        {
            tiempoRestante = 0;
            
        }
    }

    public void SumarTiempo(float tiempoASumar)
    {
        tiempoRestante += tiempoASumar;
    }
}