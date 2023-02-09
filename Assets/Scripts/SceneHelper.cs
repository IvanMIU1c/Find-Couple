using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public UnityEvent Enter;
    private void StartCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestardLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Enter.Invoke();
            StartCursor();
        }
    }
}
