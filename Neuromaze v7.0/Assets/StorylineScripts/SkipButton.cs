using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    void Start() 
    {
        Cursor.visible = true;
    }
    
    public void SkipStoryline ()
    {
        SceneManager.LoadScene("ToChapterOne", LoadSceneMode.Single);
    }
    
}
