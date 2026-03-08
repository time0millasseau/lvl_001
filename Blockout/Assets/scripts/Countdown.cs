using System.Collections;
using UnityEngine;

public class CircleScaler : MonoBehaviour
{

    public float timerDuration=30f;
    private float timer;
    public Transform target;
    public float maxRadius = 30f; //starting size
    public float minRadius = 0f; //ending size
    public bool GameOver;
    public GameObject GameOverPanel;
  


    void Awake()
    {
        
    }
    private void Start()
    {
timer=timerDuration;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        target = GetComponent<Transform>();

        if (timer > 0.5)
        {
            GameOver = false;
            Debug.Log("tout va bien");
            GameOverPanel.SetActive(false);

        }

        if (timer <= 0.5)
        {
           StartCoroutine(TimerZero());
        }

        float timerPercentage = timer / timerDuration;
        float newRadius = Mathf.Lerp(minRadius, maxRadius, timerPercentage);

        transform.localScale = new Vector3(newRadius, newRadius, 1f);
    }
    IEnumerator TimerZero()
    {
        timer = 0;
        yield return new WaitForSeconds(0.5f);
        GameOver = true;
        GameOverPanel.SetActive(true);
    }  
    }

