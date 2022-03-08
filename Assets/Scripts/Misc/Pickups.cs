using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    enum CollectibleType
    {
        POWERUP,
        SCORE,
        LIFE
    }

    [SerializedField] CollectibleType curCollectible;
    public int ScoreValue;
    // Start is called before the first frame update
    private void Start()
    {
        if (curCollectible == CollectibleType.LIFE)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
                 switch (curCollectible)
                {
                    case CollectibleType.POWERUP:
                    collision.gameObject.GetComponent<Player>().StartJumpForceChange();
                    //curPlayerScript.score += ScoreValue;
                    GameManager.instance.score += ScoreValue;
                        break;
                    case CollectibleType.LIFE:
                    //curPlayerScript.lives++;
                    //curPlayerScript.score += ScoreValue;
                    GameManager.instance.lives++;
                        break;
                    case CollectibleType.SCORE:
                    //curPlayerScript.score += ScoreValue;
                    GameManager.instance.score += ScoreValue;
                        break;
                }
            Destroy(gameObject);
        }
    }
}

internal class SerializedFieldAttribute : Attribute
{
}