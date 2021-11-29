using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pruebator : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject Misil;
    [SerializeField] float fireRate;
    [SerializeField] GameObject Enemigotorreta1Destruida;
    [SerializeField] AudioClip sfx_death;
    float nextFire = 0;
    public bool izq = false;
    Animator myAnimator;
    BoxCollider2D myCollider;
    public int vida;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Serguirmegamanizq())
        {
            //bala dirigida hacia la izqauierda
            Misil.transform.localScale = (new Vector2((transform.localScale.x * 1), transform.localScale.y));

            if (Time.time >= nextFire)
            {
                Instantiate(Misil, transform.position - new Vector3(1, 0, 0), transform.rotation);
                nextFire = Time.time + fireRate;
            }
            izq = true;
        }

        else if (Serguirmegamander())
        {
            //bala dirigida a la derecha
            Misil.transform.localScale = (new Vector2((transform.localScale.x * -1), transform.localScale.y));
            //torreta mirando a la derecha
            transform.localScale = new Vector2((transform.localScale.x * -1), transform.localScale.y);

            if (Time.time >= nextFire)
            {
                Instantiate(Misil, transform.position - new Vector3(1, 0, 0), transform.rotation);
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
        Instantiate(Enemigotorreta1Destruida, transform.position - new Vector3(0, 0.5f, 0), transform.rotation);
        this.gameObject.SetActive(false);

    }
}

