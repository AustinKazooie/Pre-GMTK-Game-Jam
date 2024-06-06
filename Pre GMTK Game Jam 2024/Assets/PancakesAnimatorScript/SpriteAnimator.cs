using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer playersprite;
    public Sprite RightSprite;
    public Sprite LeftSprite;
    public Sprite JumpSprite;
    public Sprite IdleSprite;


    //Im assuming you already have this
    public Rigidbody2D MyRigidbody;
    


    
    void Start()
    {
      
    }

    // Warning, Its pretty Jank
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {


            //add on of theses on each moving script, change what sprite for which direction.
        playersprite.sprite = RightSprite;
        MyRigidbody.velocity = Vector3.right * 5;
        }
        else if (Input.GetKey(KeyCode.A))
        {
        playersprite.sprite = LeftSprite;
        MyRigidbody.velocity = Vector3.left * 5;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
        playersprite.sprite = JumpSprite;
        MyRigidbody.velocity = Vector2.up * 5;
        }
        else
        {
            playersprite.sprite = IdleSprite;

        }
        
        
    }
}
