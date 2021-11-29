using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta3 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameManager gm;
    [SerializeField] AudioClip sfx_death;
    [SerializeField] Animator myAnimator;
    [SerializeField] GameObject Balaene;
    [SerializeField] GameObject Balaene2;
    [SerializeField] float fireRate;
    BoxCollider2D myCollider;
    public int vida;
    float nextFire =0;
    public bool izq = false;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2.Distance(transform.position, player.transform.position);

        //if (Physics2D.OverlapCircle(transform.position, 10, LayerMask.GetMask("Player")) != null)
        //{
        //Instantiate(Balaene, transform.position - new Vector3(1, 0, 0), transform.rotation);
        //nextFire = Time.time + fireRate;
        // }
        if (Serguirmegamanizq())
        {
            //bala dirigida hacia la izqauierda
            Balaene.transform.localScale = (new Vector2((transform.localScale.x * 1), transform.localScale.y));
            myAnimator.SetBool("Shoot", true);

            if (Time.time >= nextFire)
            {
                Instantiate(Balaene, transform.position - new Vector3(-1, 0, 0), transform.rotation);
                nextFire = Time.time + fireRate;
                Instantiate(Balaene2, transform.position - new Vector3(1, 0, 0), transform.rotation);
                nextFire = Time.time + fireRate;

            }
            izq = true;
        }

        else if (Serguirmegamander())
        {
            //bala dirigida a la derecha
            Balaene.transform.localScale = (new Vector2((transform.localScale.x * -1), transform.localScale.y));
            //torreta mirando a la derecha
            transform.localScale = new Vector2((transform.localScale.x * -1), transform.localScale.y);
            myAnimator.SetBool("Shoot", true);

            if (Time.time >= nextFire)
            {
                Instantiate(Balaene, transform.position - new Vector3(1, 0, 0), transform.rotation);
                nextFire = Time.time + fireRate;
                Instantiate(Balaene2, transform.position - new Vector3(1, 0, 0), transform.rotation);
                nextFire = Time.time + fireRate;
            }
            izq = false;
        }

          
        

    }
    public bool Serguirmegamanizq()
    {
        RaycastHit2D hitdeRaycast = Physics2D.Raycast(myCollider.bounds.center, new Vector2(transform.localScale.x, 0), myCollider.bounds.extents.x - 15f, LayerMask.GetMask("Player"));
        Debug.DrawRay(myCollider.bounds.center, new Vector2(transform.localScale.x, 0) * (myCollider.bounds.extents.x - 15f), Color.red);
        return hitdeRaycast.collider != null;

    }
    public bool Serguirmegamander()
    {
        Debug.Log("Mgaman esta a la derecha");
        RaycastHit2D hitdeRaycast = Physics2D.Raycast(myCollider.bounds.center, new Vector2(transform.localScale.x, 0), myCollider.bounds.extents.x + 15f, LayerMask.GetMask("Player"));
        Debug.DrawRay(myCollider.bounds.center, new Vector2(transform.localScale.x, 0) * (myCollider.bounds.extents.x + 15f), Color.red);
        return hitdeRaycast.collider != null;
    }
    //private void OnDrawGizmos()
    //{
    //Gizmos.color = Color.red;
    //Gizmos.DrawWireSphere(transform.position, 10);
    //}
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("balas")))
        {
            vida--;

            if (vida == 0)
            {
                AudioSource.PlayClipAtPoint(sfx_death, Camera.main.transform.position);
                myAnimator.SetTrigger("Destruido");
                

            }

        }

    }
    public void Destruido()
    {
        gm.Reducirnumene();
        Destroy(this.gameObject);


    }
}
