using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    public string xAxisName;
    public string yAxisName;
    public string interactName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw(xAxisName);
        moveInput.y = Input.GetAxisRaw(yAxisName);

        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;

        if (Input.GetButtonDown(interactName))
        {
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            
        }
    }
}
