//画面右のアイテム購入にまつわるクラスだよ
//実際にゴールドを増やす処理はGoldPerSecクラスがおこなうよ
//所持goldで購入できるアイテムは色が変わるよ
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public UnityEngine.UI.Text itemInfo;
	public Click click;
	public float cost;		//つぎの購入に必要な金額(変動する)
	public int tickValue;	//増加するGold(不変)		※tick value = 目盛り値？？
	public int count;		//なんこ買ったか(変動する)
	public string itemName;	//なまえ
	private float baseCost;	//最初の購入に必要な金額(不変)

	public Color affordable;				//購入できる時はこの色	※affordable=お手頃価格
	public Color standard;					//もとのいろ

	private Slider _slider;

	void Start(){
		baseCost = cost;	//最初の購入に必要なコスト baseCostの初期化といっていいのかな??

		_slider = GetComponentInChildren<Slider> ();
	}

	void Update(){
		//itemInfo.text = itemName + "(" + count + ")" + "\nCost: " + cost + "\nGold: " + tickValue + "/s";
		itemInfo.text = itemName + "(" + count + ")" + "\nCost: " + cost + "\nGold: " + tickValue + "/s";

		/*if (click.gold >= cost) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image> ().color = standard;
		}*/

		//色変える+スライダつかうver
		_slider.value = click.gold / cost * 100;
		if (_slider.value >= 100) {
			GetComponent<Image> ().color = affordable;
			_slider.enabled = false;
		} else {
			GetComponent<Image> ().color = standard;
			_slider.enabled = true;			//スライダの値が100未満だとボタンがおせないよ
		}
	}

	//所持金がコストより高かったら購入回数とcostをふやすよ
	public void PurchasedItem(){
		if (click.gold >= cost) {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
			//Debug.Log ("baseCost" + baseCost + " *" + " 1.15f" + " ^" + " count" + count);
			//Debug.Log ("=cost is" + cost);
		}
	}

}
