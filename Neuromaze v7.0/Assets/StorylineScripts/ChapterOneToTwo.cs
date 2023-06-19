using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterOneToTwo : MonoBehaviour
{
    void OnEnable() 
    {
        // temporarily will upload first game level
        SceneManager.LoadScene("GameLevelOne", LoadSceneMode.Single);
    }
}