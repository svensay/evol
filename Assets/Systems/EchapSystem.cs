using UnityEngine;
using UnityEngine.SceneManagement;
using FYFY;
using FYFY_plugins.Monitoring;

public class EchapSystem : FSystem {

	/// <summary>
	/// The echap family
	/// Représente la page d'échappe
	/// </summary>
	private Family _EchapFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Echap)));

	/// <summary>
	/// The retry monit family
	/// Composant pour tracer le clique sur recommencer du joueur
	/// </summary>
	private Family _RetryMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(RetryMonitoring), typeof(ComponentMonitoring)));


	/// <summary>
	/// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
	/// Ouvre ou ferme la page d'échappe lorsque l'on appuis sur échappe
	/// </summary>
	/// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
	/// <remarks>
	/// Called only is this <see cref="T:FYFY.FSystem" /> is active.
	/// </remarks>
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

	/// <summary>
	/// Ons the click continue.
	/// Ferme la page d'échappe.
	/// </summary>
	public void onClickContinue()
	{
		GameObjectManager.setGameObjectState(_EchapFamily.First(), false);
		Time.timeScale = 1.0f;
	}

	/// <summary>
	/// Ons the click recomence.
	/// Recommence le niveaux actuel
	/// </summary>
	/// <param name="id">The identifier.</param>
	public void onClickRecomence(int id)
	{
		foreach(GameObject go in _RetryMonitFamily)
		{
			if(go.GetComponent<RetryMonitoring>().id == id)
			{
				ComponentMonitoring cm = go.GetComponent<ComponentMonitoring>();
				MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
			}
		}

		int sceneID = SceneManager.GetActiveScene().buildIndex;
		GameObjectManager.loadScene(sceneID);
		Time.timeScale = 1.0f;
	}

	/// <summary>
	/// Ons the click quit.
	/// Quitte le jeu
	/// </summary>
	public void onClickQuit()
	{
		Application.Quit();
	}
}