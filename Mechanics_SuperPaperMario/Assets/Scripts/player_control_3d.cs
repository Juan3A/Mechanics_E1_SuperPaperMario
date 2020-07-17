using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control_3d : MonoBehaviour
{
    public Rigidbody rb;
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
            rb.velocity = Vector2.up * sd.jumpforce;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(z * sd.speed, rb.velocity.y, x * sd.speed*-1) ;

        if (dir != Vector3.zero)
        {
            if (x != 0)
            {
                sprite.flipX = (x < 0) ? false : true;
                sd.flipX = sprite.flipX;
            }
            rb.velocity = dir;
        }

    }
}
