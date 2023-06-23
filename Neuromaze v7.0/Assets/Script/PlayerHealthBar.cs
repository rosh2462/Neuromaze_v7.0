// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerHealthBar : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public int currentHealth;

//     public HealthBar healthBar;

//     public GameObject gameOverWindow;
//     bool gameIsOver = false;

//     private void Start()
//     {
//         gameOverWindow.SetActive(false);
//         currentHealth = maxHealth;
//         healthBar.SetMaxHealth(maxHealth);
//     }

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.F2))
//         {
//             TakeDamage(5);
//         }

//         if (currentHealth <= 0 && !gameIsOver)
//         {
//             GameOver();
//         }
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         healthBar.SetHealth(currentHealth);
//     }

//     public void IncreaseHealth(int amount)
//     {
//         currentHealth += amount;
//         if (currentHealth > maxHealth)
//         {
//             currentHealth = maxHealth;
//         }
//         healthBar.SetHealth(currentHealth);
//     }

//     private void GameOver()
//     {
//         gameIsOver = true;
//         gameOverWindow.SetActive(true);
//         Time.timeScale = 0;
//         Cursor.visible = true;
//     }

//     public void RestartScene()
//     {
//         Time.timeScale = 1;
//         gameIsOver = false;
//         gameOverWindow.SetActive(false);
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject damageEffectPrefab; // Prefab of the game object with sound effect

    public GameObject gameOverWindow;
    public AudioSource gameOverSound;
    public CanvasGroup canvasGroup; // Reference to the CanvasGroup component
    bool gameIsOver = false;
    bool tookDamage = false; // Variable to track if damage was taken in the current frame
    float fadeSpeed = 4f; // Speed at which the canvas fades

    private void Start()
    {
        gameOverWindow.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        canvasGroup.alpha = 0f;        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            TakeDamage(5);
        }
        
        if (Input.GetKeyDown(KeyCode.F3))
        {
            IncreaseHealth(10);
        }

        if (currentHealth <= 0 && !gameIsOver)
        {
            GameOver();
        }

        if (tookDamage)
        {
            tookDamage = false;
            StartCoroutine(FadeCanvasInAndOut());

            canvasGroup.alpha = 0.5f;
        }

        if(currentHealth >= 30 && !gameIsOver)
        {
            canvasGroup.alpha = 0f;
        }
        else
        {
            StartCoroutine(FadeCanvasInAndOut());
            canvasGroup.alpha = 1f;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (damageEffectPrefab != null)
        {
            GameObject damageEffect = Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = damageEffect.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                StartCoroutine(PlayDelayedSoundEffect(audioSource));
            }
        }

        tookDamage = true;
    }

    private IEnumerator PlayDelayedSoundEffect(AudioSource audioSource)
    {
        yield return new WaitForSeconds(0.2f); // Delay before playing the sound effect

        audioSource.Play();
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    private void GameOver()
    {
        gameIsOver = true;
        gameOverWindow.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;

        if (gameOverSound != null)
        {
            gameOverSound.Play(); // Play the game over sound effect
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        gameIsOver = false;
        gameOverWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator FadeCanvasInAndOut()
    {
        canvasGroup.alpha = 1f; // Set initial alpha to fully opaque

        yield return new WaitForSeconds(0.3f);

        float currentTime = 0f;

        while (currentTime < fadeSpeed)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeSpeed); // Calculate interpolated alpha value
            canvasGroup.alpha = alpha;
            yield return null;
        }

        canvasGroup.alpha = 0f; // Set final alpha to fully transparent
    }
}
