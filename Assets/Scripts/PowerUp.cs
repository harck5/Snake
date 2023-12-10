using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static bool isSlowed = false;
    public static bool isSpeedUp = false;
    public static float remainingTime = 0f;
    public static int duration = 5;

public static IEnumerator TimeDownCoroutine()
    {
        Time.timeScale = 0.5f; // Ralentizar el juego
        isSlowed = true;

        yield return new WaitForSecondsRealtime(duration); // Esperar 5 segundos

        Time.timeScale = 1f; // Vuelva al tiempo normal después de 5 segundos
        isSlowed = false;
        NormalTimeCoroutine();
    }

    public static IEnumerator TimeUpCoroutine()
    {
        Time.timeScale = 2f; // Acelerar el juego
        isSpeedUp = true;

        yield return new WaitForSecondsRealtime(5f); // Esperar 5 segundos

        Time.timeScale = 1f; // Vulve al tiempo normal después de 5 segundos
        isSpeedUp = false;
    }
    public static void NormalTimeCoroutine()
    {
        Time.timeScale = 1f; // Vulve al tiempo normal después de 5 segundos
        isSpeedUp = false;
        isSlowed = false;
    }
}
