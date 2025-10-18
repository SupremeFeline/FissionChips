using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Press : MonoBehaviour
{
    // public function to be called on button press
    public void start()
    {
        SceneManager.LoadScene("StyliMainScene");
      
    }

    public void quit()
    {
        
        UnityEditor.EditorApplication.isPlaying = false;
    }
}