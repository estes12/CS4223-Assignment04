using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        speed = MainMenu.carSpeed;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y); //Moves car forward no matter which way it is facing.
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
        
    }

    private void Awake()
    {
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        Object.Destroy(this.gameObject);
    }
}
