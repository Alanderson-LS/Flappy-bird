using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject message, pato;
    [SerializeField] private GameObject pipes, Source;
    private float timeToSpawn = 2f;
    private bool started;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
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
