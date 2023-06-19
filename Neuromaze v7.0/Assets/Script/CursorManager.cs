using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        // Hide the cursor when the game starts
        Cursor.visible = false;
    }

    private void Update()
    {
        // Toggle cursor visibility with the "Escape" key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }
    }
}
