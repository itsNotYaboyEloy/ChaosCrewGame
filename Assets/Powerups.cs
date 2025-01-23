using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public Type type;

    public float speedup = 4f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player1 = collision.gameObject;
            Player playerScript = player1.GetComponent<Player>();

            if (playerScript)
            {
                this.type.Apply(this, playerScript);
                Destroy(gameObject);
            }
        }
    }

    public enum Type
    {
        DoubleSpeed,
        SlowDown,
    }
}

public static class TypeExtensions
{
    public static void Apply(this Powerups.Type type, Powerups powerups, Player player)
    {
        switch (type)
        {
            case Powerups.Type.DoubleSpeed:
                player.moveSpeed += powerups.speedup;
                break;

            case Powerups.Type.SlowDown:
                player.moveSpeed -= powerups.speedup;
                break;
        }
    }
}
