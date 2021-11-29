using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    public Rigidbody2D rb;
    Animator myAnimator;
    CircleCollider2D myCollider;
    public GameObject Impacto;
    Rigidbody2D myBala;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CircleCollider2D>();
        myBala = GetComponent<Rigidbody2D>();




        rb.velocity = transform.right * speed;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
        // {
        //     myAnimator.SetBool("Explosion", true);
        //Instantiate(Impacto);
        //     Destroy(this.gameObject);
        // }

        // else
        //      myAnimator.SetBool("Explosion", false);
        //}


        // }
        Debug.Log("colision");
        //Instantiate(Impacto);
        myAnimator.SetBool("Explosion", true);
        //Destroy(this.gameObject);

    }
   
}
