using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float distancia;
    [SerializeField] float speed;
    [SerializeField] float Jumpforce;
    [SerializeField] GameObject Bala;
    [SerializeField] float sigbala = 0;
    [SerializeField] float velbala;
    [SerializeField] AudioClip sfx_bullet;
    [SerializeField] AudioClip sfx_dash;
    [SerializeField] AudioClip sfx_death;
    [SerializeField] AudioClip sfx_jump;
    [SerializeField] AudioClip sfx_land;
    [SerializeField] int vida;
    [SerializeField] GameObject gameovercanva;



    float nextFire;
    float shootCooldown=0.3f;
    public int Nsaltos=1;
    public bool doblesalto;
    public bool ensuelo;
    public bool dash;
    public float dashtiemp;
    public float veldash;
    public LayerMask Ground;
    public bool disparo;
    public bool gamepaused = false;


    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {

        myAnimator = GetComponent<Animator>();
        myBody= GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {


        if (!gamepaused)
        {
            Mover();
            Caer();
            Disparar();
            Dash();
            

        }



        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Nsaltos = 2;
                

                myBody.velocity = new Vector2(myBody.velocity.x, Jumpforce);
                myAnimator.SetTrigger("Jumping");


            }
            
        }

        Debug.Log(Nsaltos);



            if (Input.GetKeyDown(KeyCode.Space) && Nsaltos>0)
            {
                 AudioSource.PlayClipAtPoint(sfx_jump, Camera.main.transform.position);
                 Nsaltos--;

                myBody.velocity = new Vector2(myBody.velocity.x, Jumpforce);
                myAnimator.SetTrigger("Jumping");

            }

       
        

        void Disparar()
        {
            float dirH = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.C))
            {
                AudioSource.PlayClipAtPoint(sfx_bullet, Camera.main.transform.position);
                //myAnimator.SetBool("Disparo", true);
                if (dirH < 0)
                {
                    transform.localScale = new Vector2(-1, 1);

                }
                if (dirH < 0)
                {
                    transform.localScale = new Vector2(1, 1);

                }
                Instantiate(Bala, transform.position - new Vector3(0, 0), transform.rotation);
                nextFire = Time.time + shootCooldown;
                myAnimator.SetLayerWeight(1, 1);
            }
            else
            {
                if(Time.time>nextFire)
                myAnimator.SetLayerWeight(1, 0);
                //myAnimator.SetBool("Disparo", false);
            }

                


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



        //void Correr()
        //{
        //    float dirH = Input.GetAxis("Horizontal");

        //    if (dirH != 0 && !dash)
        //    {
          //      if (dirH < 0 && !dash)
            //    {
              //      transform.localScale = new Vector2(-1, 1);
                //}
                //else
                  //  transform.localScale = new Vector2(1, 1);

                //myAnimator.SetBool("isRunning", true);

                //Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, 0);
                //transform.Translate(movimiento);
            //}
            //else
                //myAnimator.SetBool("isRunning", false);

        }

        void Mover()
        {
            if (Input.GetKey(KeyCode.RightArrow) && !dash)
            {
                myAnimator.SetBool("isRunning", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.right * speed * Time.deltaTime);
             if (Input.GetKeyDown(KeyCode.C))
             {
                myAnimator.SetBool("Disparocorre", true);
             }
             else
                myAnimator.SetBool("Disparocorre", false);
        }
            else
            {
                myAnimator.SetBool("isRunning", false);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && !dash)
            {
                myAnimator.SetBool("isRunning", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
            myAnimator.SetBool("Disparocorre", true);
            }
             else
            myAnimator.SetBool("Disparocorre", false);



    }

        void Dash()
        {

            if (Input.GetKey(KeyCode.X))
            {
                dashtiemp += 1 * Time.deltaTime;
                

            if (dashtiemp < 0.35f && (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))))
                {
                    dash = true;
                    myAnimator.SetBool("Dashing", true);
                    transform.Translate(Vector3.right * veldash * Time.deltaTime);
                    //myBody.velocity = new Vector2(10, 0);
                }
                else
                {
                    dash = false;
                    myAnimator.SetBool("Dashing", false);

                }

            }
            else
            {
                dash = false;
                myAnimator.SetBool("Dashing", false);
                dashtiemp = 0;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
            AudioSource.PlayClipAtPoint(sfx_dash, Camera.main.transform.position);

            }
        }
         

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("balasenemigo")))
        {

            vida = 0;
            this.gameObject.SetActive(false);
            gameovercanva.SetActive(true);
            AudioSource.PlayClipAtPoint(sfx_death, Camera.main.transform.position);

        }

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Enemigo")))
        {
            vida = 0;
            this.gameObject.SetActive(false);
            gameovercanva.SetActive(true);
            AudioSource.PlayClipAtPoint(sfx_death, Camera.main.transform.position);
        }

    }
  }
  

