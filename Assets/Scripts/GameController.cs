using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText,restartText,gameOverText;
	private  int score;
	private bool gameOver;
	private bool restart;
	// Use this for initialization
	void Start () {
		restartText.text = gameOverText.text = "";

		score = 0;
		gameOver = false;
		restart = false;
		UpdateScore ();
		StartCoroutine (SpawnWave ());
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if(Input .GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWave(){
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i=0; i<hazardCount;i++){
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate (hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver){
				restartText.text="Press R to Restart";
				restart =true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValues){
		score += newScoreValues;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score:" + score;
	}

	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver=true;
	}
}
