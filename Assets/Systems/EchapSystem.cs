using UnityEngine;
using UnityEngine.SceneManagement;
using FYFY;

public class EchapSystem : FSystem {

	private Family _EchapFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Echap)));

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (Input.GetKey(KeyCode.Escape))
		{
			if (_EchapFamily.First().activeSelf)
			{
				Time.timeScale = 1.0f;
				GameObjectManager.setGameObjectState(_EchapFamily.First(), false);
			}
			else
			{
				Time.timeScale = 0.0f;
				GameObjectManager.setGameObjectState(_EchapFamily.First(), true);
			}
		}
	}

	public void onClickContinue()
	{
		GameObjectManager.setGameObjectState(_EchapFamily.First(), false);
		Time.timeScale = 1.0f;
	}

	public void onClickRecomence()
	{
		int sceneID = SceneManager.GetActiveScene().buildIndex;
		GameObjectManager.loadScene(sceneID);
		Time.timeScale = 1.0f;
	}
	
	public void onClickQuit()
	{
		Application.Quit();
	}
}