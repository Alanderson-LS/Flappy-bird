using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject message, pato;
    [SerializeField] private GameObject pipes, Source, gameOver;
    [SerializeField] private Text scoreText;
    private float timeToSpawn = 2f;
    private bool started;
    private int score;
    private bool finished = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gameOver.SetActive(false);
        score = 0;
        InvokeRepeating("SpawnPipes", 0f, timeToSpawn);
        started = false;
    }

    private void SpawnPipes()
    {
        int numero = Random.Range(-2, 3);
        Vector3 pos = Source.transform.position;

        pos.y += numero;

        if (!started) return;

        Instantiate(
            pipes,
            pos,
            Quaternion.identity
        );
    }

    public void IncreaseScore(int scoreAdd)
    {
        this.score += scoreAdd;
        Debug.Log(score);
        scoreText.text = $"{score}";
        
    }

    public void GameOver()
    {
        this.finished = true;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public bool CheckFinish()
    {
        return this.finished;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            // message.SetActive(true)
            Destroy(message);
            pato.SetActive(true);
            started = true;
        }
    }

}
