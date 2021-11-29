using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    [SerializeField] GameObject Misil;
    BoxCollider2D myCollider;
    [SerializeField] float fireRate;
    public float nextFire=0;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
        Debug.Log("Disparar al jugador" + DetectarJugadorizq());

        void Disparar()
        {

            if (DetectarJugadorizq() == true)
            {

                //transform.localScale = new Vector2(1, 1);
                //Instantiate(Misil, transform.position - new Vector3(0, 0), transform.rotation);
                if (Time.time >= nextFire)
                {
                    Instantiate(Misil, transform.position - new Vector3(1, 0, 0), transform.rotation);
                    nextFire = Time.time + fireRate;
                }
            }
            
        }

    }

    public bool DetectarJugadorizq()
    {
        RaycastHit2D raycast_player = Physics2D.Raycast(myCollider.bounds.center, Vector2.left, 15f, LayerMask.GetMask("Player"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.left * 15f, Color.red);

        return (raycast_player.collider != null);


    }
    public bool DetectarJugadorder()
    {
        RaycastHit2D raycast_player = Physics2D.Raycast(myCollider.bounds.center, Vector2.right, 15f, LayerMask.GetMask("Player"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.right * 15f, Color.red);

        return (raycast_player.collider != null);


    }

}