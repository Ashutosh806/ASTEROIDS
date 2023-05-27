using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxLifetime = 10.0f;
    private Rigidbody2D rb2;

    private void Awake() 
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
       rb2.AddForce(direction*this.speed);
       Destroy(this.gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(this.gameObject);
    }
}
