using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToChapterTwo : MonoBehaviour
{
    void OnEnable() 
    {
        // temporarily will upload first game level
        SceneManager.LoadScene("ToChapterTwo", LoadSceneMode.Single);
        //Cursor.visible = true;
    }
}