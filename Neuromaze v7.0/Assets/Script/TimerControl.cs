
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class TimerControl : MonoBehaviour
// {
//     Image timerBar;
//     public float maxTime;
//     float timeLeft;
//     public GameObject gameOverWindow;

//     bool gameIsOver = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         gameOverWindow.SetActive(false);
//         timerBar = GetComponent<Image>();
//         timeLeft = maxTime;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (!gameIsOver)
//         {
//             if (timeLeft > 0)
//             {
//                 timeLeft -= Time.deltaTime;
//                 timerBar.fillAmount = timeLeft / maxTime;
//             }
//             else
//             {
//                 GameOver();
//             }
//         }
//     }

//     void GameOver()
//     {
//         gameIsOver = true;
//         gameOverWindow.SetActive(true);
//         Time.timeScale = 0;

//         Cursor.visible = true;
//     }

//     public void RestartScene()
//     {
//         Time.timeScale = 1;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    Image timerBar;
    public float maxTime;
    float timeLeft;
    public GameObject gameOverWindow;

    bool gameIsOver = false;

    private void Start()
    {
        gameOverWindow.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;

        PickUpSystemTime.OnPickUp += HandlePickUp;
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        gameOverWindow.SetActive(true);
        Time.timeScale = 0;

        Cursor.visible = true;
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    private void HandlePickUp(float extraTime)
    {
        timeLeft += extraTime;
        timeLeft = Mathf.Clamp(timeLeft, 0f, maxTime);
    }

    private void OnDestroy()
    {
        PickUpSystemTime.OnPickUp -= HandlePickUp;
    }
}
