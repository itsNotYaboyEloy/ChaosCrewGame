using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PickUp : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player)
        {
            this.transform.position = this.player.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.player)
            return;

        if (collision.CompareTag(this.player.deliveryStation))
        {
            if (this.player.doubleMoney)
                this.player.score += 2;
            else
                this.player.score += 1;

            Debug.Log(player.score);
            player.scoreUI.text = $"{player.score}";
            this.player.pickUp = null;
            Destroy(this.gameObject);
        }
    }
}

