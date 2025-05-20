using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CatAttributes : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    private Animator animator;
    public GameObject gameOverPanel;
    public List<Sprite> healthImages;
    public Image healthContainer;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverPanel.SetActive(false);

        animator = GetComponent<Animator>();
        animator.Play("Cat Animation");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Cat Health: " + currentHealth);

        StartCoroutine(PlayHitAnimation());

        if (currentHealth <= 0)
        {
            GameOver();
        }
        UpdateHealthUI();
    }

    IEnumerator PlayHitAnimation()
    {
        animator.enabled = false;
        yield return null;

        animator.enabled = true;
        animator.Play("Cat Hit");

        yield return new WaitForSeconds(1f);

        if (currentHealth > 0)
        {
            animator.Play("Cat Animation");
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }

    void UpdateHealthUI()
    {
        int index = Mathf.Clamp(maxHealth - currentHealth, 0, healthImages.Count - 1);
        healthContainer.sprite = healthImages[index];
    }
}
