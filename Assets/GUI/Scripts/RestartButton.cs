using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
	public void OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
