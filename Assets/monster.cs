using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{

    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    
        if (collision.gameObject.CompareTag("player"))
        {
            ani.SetBool("die", true);
            Destroy(this.gameObject, 1.0f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
