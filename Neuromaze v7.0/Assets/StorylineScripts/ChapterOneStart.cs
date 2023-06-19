using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterOneStart : MonoBehaviour
{
    void OnEnable() 
    {
        SceneManager.LoadScene("GameLevelOne", LoadSceneMode.Single);
        Cursor.visible = false;
    }
}
