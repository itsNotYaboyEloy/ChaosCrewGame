using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    public string xAxisName;
    public string yAxisName;
    public string interactName;
    public int score;
    public TMP_Text scoreUI;

    public PickUp pickUp;
    public string deliveryStation;

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

        //Pickup
        if (Input.GetButtonDown(interactName))
        {
            if (this.pickUp)
            {
                // drop
                if (this.pickUp.player == this)
                {
                    this.pickUp.player = null;
                }

                // steal from other player
                else if (this.pickUp.player)
                {
                    this.pickUp.player = this;
                }
                
                // pick up
                else
                {
                    this.pickUp.player = this;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            GameObject pickUpObject = collision.gameObject;
            PickUp pickUp = pickUpObject.GetComponent<PickUp>();
            if (this.pickUp == null)
            {
                this.pickUp = pickUp;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            GameObject pickUpObject = collision.gameObject;
            PickUp pickUp = pickUpObject.GetComponent<PickUp>();
            if (this.pickUp == pickUp)
            {
                this.pickUp = null;
            }
        }
    }
}
