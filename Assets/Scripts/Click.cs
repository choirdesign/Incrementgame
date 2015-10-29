// 真ん中のボタンを押したらgoldがふえるよ
// 画面中央下のGPCを更新するよ
//
using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text goldDisplay; //ボタンの上の所持Gold
	public float gold = 0.00f;				//初期所持Gold
	public int goldPerClick = 1;			//初期PerClick

	public UnityEngine.UI.Text gpc;			//画面右のGPC


	void Update(){
		//goldDisplay.text = "Gold: " + gold;	//所持Gold更新
		//goldDisplay.text = "Gold: " + gold.ToString ("F0");	//所持Gold更新 F0=小数点0けたまで表示 
		goldDisplay.text = "Gold: " + CurrencyConverter.Instance.GetCurrencyIntoString(gold, false, false);

		//gpc.text = goldPerClick + " gold/click";
		gpc.text = CurrencyConverter.Instance.GetCurrencyIntoString(goldPerClick, false, true) + " gold/click";
	}

	public void Clicked(){
		gold += goldPerClick;				//ボタンクリックで現在のGPC分goldを追加
	}

}