using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    public static bool isSlowed = false;
    public static bool isSpeedUp = false;
    public IEnumerator TimeDownCoroutine()
    {
        Time.timeScale = 0.5f; // Ralentizar el juego
        isSlowed = true;

        yield return new WaitForSeconds(5f);

        Time.timeScale = 1f; // Vuelva al tiempo normal después de 5 segundos
        isSlowed = false;
    }

    public static IEnumerator TimeUpCoroutine()
    {
        Time.timeScale = 2f; // Acelerar el juego
        isSpeedUp = true;

        yield return new WaitForSeconds(5f); // Esperar 5 segundos

        Time.timeScale = 1f; // Vulve al tiempo normal después de 5 segundos
        isSpeedUp = false;
    }

    /*bool isSlowedDown = false;
    bool isSpeedUp = false;
    public float originalTimeScale = 1;
    private IEnumerator TimeDownCoroutine()
    {
        Time.timeScale = 0.5f; // Ralentizar el juego

        yield return new WaitForSecondsRealtime(5f); // Esperar 5 segundos

        Time.timeScale = originalTimeScale; // Restaurar el tiempo original
        isSlowedDown = false;
    }

    private IEnumerator TimeUpCoroutine()
    {
        Time.timeScale = 2f; // Acelerar el juego

        yield return new WaitForSecondsRealtime(5f); // Esperar 5 segundos

        Time.timeScale = originalTimeScale; // Restaurar el tiempo original
        isSpeedUp = false;
    }
    public static IEnumerator TimeDownCoroutine()
    {
        Time.timeScale = 0.5f; // Ralentizar el juego

        yield return new WaitForSecondsRealtime(5f); // Esperar 5 segundos

        Time.timeScale = 1f; // Restaurar el tiempo original después de 5 segundos
    }

    public static IEnumerator TimeUpCoroutine()
    {
        Time.timeScale = 2f; // Acelerar el juego

        yield return new WaitForSecondsRealtime(5f); // Esperar 5 segundos

        Time.timeScale = 1f; // Restaurar el tiempo original después de 5 segundos
    }*/
    
}