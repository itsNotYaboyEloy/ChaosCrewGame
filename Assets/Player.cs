using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    //Movement Keys
    public string xAxisName;
    public string yAxisName;
    //Interact
    public string interactName;
    //Score
    public int score;
    public TMP_Text scoreUI;

    //Pickups & Delivery
    public PickUp pickUp;
    public string deliveryStation;

    //PowerUps
        public float powerUpDisableTime = 0;
        //DoubleMoney
        public bool doubleMoney;
        // 
        public bool higherSpeed;
        // 
        public bool lowerSpeed;
        //
        public bool confusion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = this.moveSpeed;
        if (lowerSpeed)
            moveSpeed /= 2;
        else if (higherSpeed)
            moveSpeed *= 2;
        else if (confusion)
            moveSpeed *= -1;

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


        if (Time.time > this.powerUpDisableTime)
        {
            doubleMoney = false;
            lowerSpeed = false;
            higherSpeed = false;
            confusion = false;
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
