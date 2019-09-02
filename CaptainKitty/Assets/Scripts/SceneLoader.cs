using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	//Identifies the current scene and invokes the appropriate method for loading the next scene
	public void LoadNextScene()
	{
		Scene currentScene = SceneManager.GetActiveScene();

		if (currentScene == SceneManager.GetSceneByName("Title"))
		{
			LoadMainLevel();
		}
		else if (currentScene == SceneManager.GetSceneByName("Level"))
		{
			LoadEndScene();
		}
		else
		{
			LoadTitleScene();
		}
	}

		private void LoadTitleScene()
		{
			SceneManager.LoadScene("Title");
		}

		private void LoadMainLevel()
		{
			SceneManager.LoadScene("Level");
		}

		public void LoadEndScene()
		{
            SceneManager.LoadScene("End");
		}

    public void EndGame()
    {
        Debug.Log("Trying to end the game");
        Application.Quit();
    }
}
