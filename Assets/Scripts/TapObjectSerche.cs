///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// タップしたオブジェクトを返す
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObjectSerche : MonoBehaviour {

	/// <summary>
	/// タップしたオブジェクトが何かを返すメソッド
	/// </summary>
	/// <returns>ゲームオブジェクト</returns>
	public GameObject getClickObject(){
		GameObject result = null;
			　　　
		Vector2 tapPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);　　
		Collider2D collition2d = Physics2D.OverlapPoint (tapPoint);
			　　　
		if (collition2d) {　
			result = collition2d.transform.gameObject;
		}
		return result;
	}
}
