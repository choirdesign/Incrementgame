using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {

		MainGameManager.instance.AdjustScore (-1000);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
