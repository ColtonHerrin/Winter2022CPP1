using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Pickups : MonoBehaviour
{

    enum CollectibleType
    {
        POWERUP,
        SCORE,
        LIFE
    }

    [SerializedField] CollectibleType curCollectible;
    [SerializedField] AudioClip pickupSound;
    AudioSource myAudioSource;
    public int ScoreValue;

    public AudioMixerGroup soundFXGroup;
    // Start is called before the first frame update
    private void Start()
    {
        if (!myAudioSource)
            myAudioSource = GetComponent<AudioSource>();
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
            PlayerSounds ps = collision.gameObject.GetComponent<PlayerSounds>();
            ps.Play(pickupSound, soundFXGroup);

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