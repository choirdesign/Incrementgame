using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {

	private int _currentScore;
	public static MainGameManager instance;


	void Awake () {
		instance = this;
	}

	public void AdjustScore (int num) {
		_currentScore = _currentScore + num;
	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 100), "Score = " + _currentScore);
	}
}
