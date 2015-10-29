//ItemManagerの情報をもとに所持金を増やすよ 画面中央下のGoldPerSecにくっついてるよ

//1StartでコルーチンAutoTick()が呼ばれるよ
//2AutoTick()は10分の1秒毎にAutoGoldPerSec()を呼ぶよ
//3AutoGoldPerSec()はGetGoldPerSec/10分のゴールドを増やすよ
//4GoldPerSecは買ったアイテムそれぞれの購入回数*ベース増加値の合計をfloatで戻すよ

using UnityEngine;
using System.Collections;

public class GoldPerSec : MonoBehaviour {

	public UnityEngine.UI.Text gpsDisplay;
	public Click click;
	public ItemManager[] items;	//アイテムの配列(アップグレードのボタンぜんぶ)


	//1コルーチン発動
	void Start() {
		StartCoroutine (AutoTick ());
	}

	//-画面更新
	void Update() {
		gpsDisplay.text = GetGoldPerSec () + " gold/sec";
	}

	//4 ここで1/10ごとにいくらゴールドを増やせばいいか計算
	public float GetGoldPerSec() {	
		float tick = 0;		//初期化
		foreach (ItemManager item in items) {		//入ってる要素ぜんぶにおこなう
			tick += item.count * item.tickValue;	//アイテム買った回数*不変のGold増える値
		}
		return tick;
	}

	//3 ここで1/10秒ごとにゴールドが増える
	public void AutoGoldPerSec() {
		//click.gold += GetGoldPerSec ();
		click.gold += GetGoldPerSec () / 10; //10分の1秒毎にゴールドふやす GetGoldPerSec=float値
	}

	//2 0.1秒毎にひたすらAutGoldPerSec
	IEnumerator AutoTick() {
		//無限ループ
		while (true) {
			AutoGoldPerSec ();
			//yield return new WaitForSeconds (1);
			yield return new WaitForSeconds (0.10f); //数字が1ずつふえるようになる というより10分の1秒ごとに処理をくりかえしている
		}
	}
}
