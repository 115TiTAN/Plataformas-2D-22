using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public HealthBar healthBar;
    private string target_tag;
    public Vector2 knockback;
    public enum DeathMode { Destroy, Teleport, SceneReload }
    public DeathMode deathMode = DeathMode.Destroy;

    public Transform teleportPoint;
    SpriteRenderer renderer;
    public Color tint_normal;
    public Color tint_invencible;
    Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision, int damage)
    {
        if (collision.tag == target_tag)
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    internal void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float healthPercentage = (float)currentHealth / (float)maxHealth;
        healthBar.SetHealth(healthPercentage);
    }

    public void Death()
    {
        if (deathMode == DeathMode.Destroy)
        {
            Destroy(gameObject);
    }
        if (deathMode == DeathMode.Teleport)
        {
            currentHealth = maxHealth;
            transform.position = teleportPoint.position;
            rb.velocity = new Vector2(0, 0);
           
        }
        if (deathMode == DeathMode.SceneReload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Debug.Log("Death");
    }
}