using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float horiznotalImput;
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 10;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Text text;

    [SerializeField] GameObject bulletPrefab;

    private int coinCount = 0;

    Rigidbody2D rb;
    private int collisions;

    private void Start()
    {
        text.text = "Coins: " + coinCount.ToString();
        rb = GetComponent<Rigidbody2D>();
    } 

    void FixedUpdate()
    {
        horiznotalImput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            if (horiznotalImput > 0) 
            {
                Shoot(true);
            }
            if (horiznotalImput < 0) 
            {
                Shoot(false);
            }
        }

        MovementLogic(horiznotalImput);
        JumpLogic();

        if (transform.position.y < -10f) 
        {
            Die();
        }
    }

    private void Shoot(bool isRight) 
    {
        if (isRight)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,0));
        }
        else 
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,180));
        }
    }

    private void MovementLogic(float horizontal) 
    {
        float abs = Mathf.Abs(horiznotalImput);
        if (animator != null)
        {
            animator.SetFloat("Speed", abs);
        }
        if (sr != null)
        {
            if (horiznotalImput > 0)
            {
                sr.flipX = true;
            }
            if (horiznotalImput < 0)
            {
                sr.flipX = false;
            }
        }
        transform.Translate(Vector2.right * horiznotalImput * speed * Time.fixedDeltaTime);
    }

    private void JumpLogic() 
    {
        if (Input.GetKey(KeyCode.Space) && collisions > 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisions++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisions--;
    }

    void Die() 
    {
        SceneManager.LoadScene(0);
        //Application.LoadLevel(0);
    }

    public void AddCoins(int coinsToAdd) 
    {
        coinCount += coinsToAdd;
        text.text = "Coins: " + coinCount.ToString();
    }
}
