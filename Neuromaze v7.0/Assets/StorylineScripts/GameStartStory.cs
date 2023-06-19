using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartStory : MonoBehaviour
{
    void OnEnable() 
    {
        SceneManager.LoadScene("ToChapterOne", LoadSceneMode.Single);
    }
}
