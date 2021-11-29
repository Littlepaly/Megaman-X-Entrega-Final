using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misilenemigo : MonoBehaviour
{
   
    public float speed;
    public Rigidbody2D rb;
    bool destruido = false;
    bool acababala = false;
    
    private GameObject Enemigotorreta1;
    Animator myAnimator;



    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //torreta = GameObject.Find("EnemigoTorreta");

        //rb.velocity = transform.right * speed;
        rb.velocity = Vector3.left*speed;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(new Vector2(transform.localScale.x * -speed * Time.deltaTime, 0));
        //Destruirbala();

    }





    //public void Acabafuncionbala()
    //{
       // acababala = true;
        //if (acababala == true)
        //{
            //Destroy(this.gameObject);
        //}
    //}
    //public void Destruirbala()
    //{
        //destruido = true;
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
         {
             
             Destroy(this.gameObject);
         }

        if (rb.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            
            Destroy(this.gameObject);
        }
    }


}

