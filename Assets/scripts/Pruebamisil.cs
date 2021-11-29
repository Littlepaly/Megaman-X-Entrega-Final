using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebamisil : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool destruido = false;
    bool acababala = false;
    private GameObject Pruebator;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Pruebator = GameObject.Find("EnemigoTorreta");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(transform.localScale.x * -speed * Time.deltaTime, 0));
        Destruirbala();

    }
    public void Acabafuncionbala()
    {
        acababala = true;
        if (acababala == true && (rb.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            Destroy(this.gameObject);
        }
    }
    public void Destruirbala()
    {
        
           destruido = true;
        
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(this.gameObject);
        }
            

        if (destruido == true)
        {
            
            speed = 0;

        }
    }
}
