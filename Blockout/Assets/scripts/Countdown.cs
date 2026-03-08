using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float timerDuration = 30f;
    private float timer;

    public float maxRadius = 30f;
    public float minRadius = 0f;

    public bool GameOver;
    public GameObject GameOverPanel;

    private Light playerLight;

    private bool coroutineStarted = false;

    void Start()
    {
        timer = timerDuration;
        playerLight = GetComponent<Light>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        float timerPercentage = timer / timerDuration;

        // Réduction du rayon et de l'intensité
        playerLight.range = Mathf.Lerp(minRadius, maxRadius, timerPercentage);
        playerLight.intensity = Mathf.Lerp(1f, 0f, 1 - timerPercentage);

        if (timer > 0.5f)
        {
            GameOver = false;
            GameOverPanel.SetActive(false);
        }
        else if (!coroutineStarted)
        {
            StartCoroutine(TimerZero());
            coroutineStarted = true;
        }
    }

    IEnumerator TimerZero()
    {
        timer = 0;
        yield return new WaitForSeconds(0.5f);

        GameOver = true;
        GameOverPanel.SetActive(true);
    }
}