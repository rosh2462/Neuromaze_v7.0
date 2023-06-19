// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerHealthBar : MonoBehaviour
// {

// 	public int maxHealth = 100;
// 	public int currentHealth;

// 	public HealthBar healthBar;

// 	public GameObject gameOverWindow;
// 	bool gameIsOver = false;

//     // Start is called before the first frame update
//     void Start()
//     {
// 		gameOverWindow.SetActive(false);

// 		currentHealth = maxHealth;
// 		healthBar.SetMaxHealth(maxHealth);
//     }

//     // Update is called once per frame
//     void Update()
//     {
// 		if (Input.GetKeyDown(KeyCode.F2))
// 		{
// 			TakeDamage(5);
// 		}

// 		if (currentHealth <= 0 && !gameIsOver)
//         {
//             GameOver();
//         }
//     }

// 	void TakeDamage(int damage)
// 	{
// 		currentHealth -= damage;

// 		healthBar.SetHealth(currentHealth);
// 	}


// 	void GameOver()
//     {
//         gameIsOver = true;
//         gameOverWindow.SetActive(true);
//         Time.timeScale = 0;

//         Cursor.visible = true;
//     }

// 	public void RestartScene()
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

public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject gameOverWindow;
    bool gameIsOver = false;

    private void Start()
    {
        gameOverWindow.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            TakeDamage(5);
        }

        if (currentHealth <= 0 && !gameIsOver)
        {
            GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        gameIsOver = false;
        gameOverWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
