using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaenemigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (transform.up + transform.right * -1) * 20f;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(this.gameObject);
        }

    }
}
