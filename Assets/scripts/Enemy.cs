using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameManager gm;
    [SerializeField] AudioClip sfx_death;
    private GameObject path;
    [SerializeField] Animator myAnimator;
    CircleCollider2D myCollider;
    public int vida;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CircleCollider2D>();
        myAnimator = GetComponent<Animator>();
        path = GameObject.Find("Path");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2.Distance(transform.position, player.transform.position);

        if (Physics2D.OverlapCircle(transform.position, 10, LayerMask.GetMask("Player")) != null)
        {
            path.SetActive(true);

        }
        else
        {
            path.SetActive(false);
        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
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
                path.SetActive(false);

            }
            
        }
        
    }
    public void Destruido()
    {
        gm.Reducirnumene();
        Destroy(this.gameObject);
        

    }

}
