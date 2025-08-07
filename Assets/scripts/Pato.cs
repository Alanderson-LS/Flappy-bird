using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using System.IO;

public class Pato : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jumping;
    [SerializeField] private GameObject pato;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private GameController GameController;

    private GameObject messageObj;
    // Start is called before the first frame update
    void Start()
    {
        messageObj = GameObject.Find("message");
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
        if (messageObj != null)
        {
            rb.constraints = rb.constraints | RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rb.constraints = rb.constraints & ~RigidbodyConstraints2D.FreezePositionY;
        }

    }

    async Task FixedUpdate()
    {
        if (jumping && !GameController.CheckFinish())
        {
            rb.velocity = Vector2.up * jumpSpeed; //(0, 1)
            jumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("pipe"))
        {
            GameController.GameOver();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreCollider"))
        {
            GameController.IncreaseScore(1);
        } 
    }
}
