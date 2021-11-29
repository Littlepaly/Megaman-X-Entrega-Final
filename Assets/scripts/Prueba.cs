using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] public float distancia;
    [SerializeField] float speed;
    [SerializeField] float Jumpforce;
    [SerializeField] GameObject Bala;
    [SerializeField] float sigbala = 0;
    [SerializeField] float velbala;

    public int Nsaltos = 1;
    public bool doblesalto;
    public bool ensuelo;
    public bool dash;
    public float dashtiemp;
    public float veldash;
    public LayerMask Ground;

    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {

        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Correr();

        Caer();
        Disparar();
        



        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Nsaltos = 1;
        }

        if (ensuelo || Nsaltos > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Nsaltos--;

                myBody.velocity = new Vector2(myBody.velocity.x, Jumpforce);
                myAnimator.SetTrigger("Jump");

            }
        }

        void Disparar()
        {
            if (Input.GetKey(KeyCode.C))
            {
                Instantiate(Bala, transform.position - new Vector3(2, 0, 0), transform.rotation);
                myAnimator.SetLayerWeight(1, 1);
            }
            else
                myAnimator.SetLayerWeight(1, 0);

            //else if (Time.time >= balarat)
            //{
            //  myAnimator.SetLayerWeight(1,0);
            //balarat = Time.time + 1.5f;
            //}
            if (Input.GetKey(KeyCode.C) && Time.time >= sigbala)
            {
                Instantiate(Bala, transform.position - new Vector3(2, 0, 0), transform.rotation);
                sigbala = Time.time + velbala;
            }
            myAnimator.SetLayerWeight(1, 0);
        }




        void Caer()
        {
            if (myBody.velocity.y < 0)
            {
                myAnimator.SetBool("Falling", true);
            }

            if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAnimator.SetBool("Falling", false);
            }
            else
                myAnimator.SetBool("Falling", true);
        }



        void Correr()
        {
            {
                if (Input.GetKey(KeyCode.D) && !dash)
                {
                    myAnimator.SetBool("isRunning", true);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                }
                else
                {
                    myAnimator.SetBool("isRunning", false);
                }
                if (Input.GetKey(KeyCode.A) && !dash)
                {
                    myAnimator.SetBool("isRunning", true);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                }
                else
                {
                    myAnimator.SetBool("isRunning", false);
                }
            }

        }

    }
}
