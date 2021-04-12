using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator ani;

    private Transform tra;

    private Rigidbody2D rigid;
    private float hor =  0.0f;
    // private float ver = 0.0f;
    bool jumpOn = true;
    private float moving_speed = 5.0f;

    private float jumppower = 6.0f;



   private void player_Moving_Control()
    {
        hor = Input.GetAxis("Horizontal");
      //  ver = Input.GetAxis("Vertical");

      
        if(hor < 0.0f)
        {
            tra.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            Vector3 moveDirect = (Vector2.right * -hor );
            tra.Translate(moveDirect.normalized * Time.deltaTime * moving_speed);
        }
        else if(hor > 0.0f)
        {
            tra.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Vector3 moveDirect = (Vector2.right * hor );
            tra.Translate(moveDirect.normalized * Time.deltaTime * moving_speed);
        }
        else
        {
           
        }
      
  
    
     /*   if (ver != 0.0f) {

            ani.SetBool("run", true);
        }*/
        if (hor != 0.0f)
        {

            ani.SetBool("run", true);
        }

        else
        {
            ani.SetBool("run", false);
        }




    }
    // Start is called before the first frame update
 

    void jump()
    {


        if (Input.GetKeyDown(KeyCode.Space)&& jumpOn ==true)
        {
            ani.SetBool("jump", true);
            rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
            jumpOn = false;
        }


 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpOn = true;
       
        if (collision.gameObject.CompareTag("ground"))
        {
            ani.SetBool("jump", false);
        }
        if (collision.gameObject.CompareTag("MON"))
        {
        
            rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
            jumpOn = false;
            
            Destroy(collision.gameObject,1.0f);
        }

    }
    void Start()
    {
        tra = GetComponent<Transform>();
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        player_Moving_Control();
    
    }
}
