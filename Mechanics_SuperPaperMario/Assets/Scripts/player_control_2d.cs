using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control_2d : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SwitcherDimensions sd;
    public SpriteRenderer sprite;

    private void OnEnable()
    {
        sprite.flipX = sd.flipX;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb2d.velocity = Vector2.up *sd.jumpforce;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if (x!= 0)
        {
            sprite.flipX = (x < 0) ? false : true;
            sd.flipX = sprite.flipX;
            rb2d.velocity = new Vector2(x*sd.speed, rb2d.velocity.y);
        }      
    }
}
