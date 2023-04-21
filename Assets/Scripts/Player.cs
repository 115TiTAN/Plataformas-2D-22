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
    public GameObject DeathMenuUI;
    public GameObject Playeres;

    public Transform teleportPoint;
    public int damage;
    SpriteRenderer renderer;
    public Color tint_normal;
    public Color tint_invencible;
    Rigidbody2D rb;

    void Start()
    {
        Playeres.SetActive(true);
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
    public void OnTriggerEnter2D(Collider2D collision)
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
        currentHealth = maxHealth;
        Playeres.SetActive(false);
        DeathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Death");
    }
}