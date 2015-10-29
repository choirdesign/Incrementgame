//画面左のアップグレードに関するスクリプトだよ アップグレードボタンにはそれぞれアタッチされているよ
//Mine Goldボタンで1クリックどのくらいお金がもらえるかを計算するよ
//所持goldで購入できるアイテムは色が変わるよ
//Sliderが100になったらSliderを解除したいよ
using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//色をいじるのにつかう

public class UpGradeManager : MonoBehaviour {

	public Click click;						//clickクラスのインスタンス
	public UnityEngine.UI.Text itemInfo;	//アップグレードの名前がはいるテキスト
	public float cost;						//アップグレードを買うためのコスト
	public int count = 0;					//アップグレードを買うたびに増えるカウント
	public int clickPower;					//アップグレードを購入すると増えるGPC
	public string itemName;					//アイテムの名前
	private float baseCost;					//private
	public Color affordable;				//購入できる時はこの色	※affordable=お手頃価格
	public Color standard;					//もとのいろ
	private Slider _slider;					//スライダをあやつる

	void Start () {
		baseCost = cost;					//アップグレードを買うためのコスト

		_slider = GetComponentInChildren<Slider> ();	//子要素にはこうやってアクセスできるのか!
	}

	//そうか、\nは改行だったのか・・・
	void Update(){
		//アップグレードの名前(購入回数)\n現在購入に必要なコスト\n増加するCP
		itemInfo.text = itemName + "(" + count + ")" + "\nCost: " + cost + "\nPower: +" + clickPower;
	
		//色かえる
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

	public void PurchasedUpgrade(){
		if (click.gold >= cost) {		//所持Goldがコストを上回っていたら買える
			click.gold -= cost;			//所持Gold - コスト
			count += 1;					//購入回数+1
			click.goldPerClick += clickPower;				//現在のGPCがふえる
			//cost = Mathf.Round (cost * 1.15f);				//costが1.15倍増える(端数はRoundで四捨五入)

			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count)); //cost = 1.15fの購入回数乗 × ベースコスト(変わらない)
			//Debug.Log ("baseCost" + baseCost + " *" + " 1.15f" + " ^" + " count" + count);
			//Debug.Log ("=cost is" + cost);
		}
	}

}
