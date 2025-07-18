using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Pato : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jumping;
    [SerializeField] private GameObject pato;
    [SerializeField] private float jumpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espaço");
            jumping = true;
        }
    }

    async Task FixedUpdate()
    {
        if (jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed; //(0, 1)
            jumping = false;
        }
    }
}
