///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// タイトルのタップ文字の効果(フェードインフェードアウト)をつけるクラス
///////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaptoStart : MonoBehaviour {

	/// <summary>
	/// フェードイン、フェードアウトするテキスト
	/// </summary>
	[SerializeField]
	Text TapText;

	/// <summary>
	/// フェードイン、フェードアウトする間隔
	/// </summary>
	const float FadeTime = 1.5f;
	/// <summary>
	/// 経過時間
	/// </summary>
	float ElapsedTime;
	/// <summary>
	/// フェードアウト、フェードイン判定
	/// </summary>
	bool FadeFlag;

	void Start () {
		ElapsedTime = FadeTime;
		FadeFlag = true;
	}

	void Update () {
		if (!!FadeFlag) {
			ElapsedTime -= Time.deltaTime;
			FadeOut ();
		} else {
			ElapsedTime += Time.deltaTime;
			FadeIn ();
		}
	}

	/// <summary>
	/// フェードイン処理を行うメソッド
	/// </summary>
	void FadeIn(){
		var alpha = ElapsedTime / FadeTime;		// 色のアルファの値 
		var color = TapText.color;		// オブジェクトの色を一時保存
		color.a = alpha;
		TapText.color = color;
		if(alpha >= 1){
			FadeFlag = true;
		}
	}

	/// <summary>
	/// フェードアウトを行うメソッド
	/// </summary>
	void FadeOut(){
		var alpha = ElapsedTime / FadeTime;		// 色のアルファの値 
		var color = TapText.color;		// オブジェクトの色を一時保存
		color.a = alpha;
		TapText.color = color;
		if(alpha <= 0.3){
			FadeFlag = false;
		}
	}
}
