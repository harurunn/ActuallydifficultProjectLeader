///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// シーン遷移時のフェードイン・アウトを制御するためのクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// コンストラクタの隠蔽を行ってnewできなくする
	SceneController(){}

	#region Singleton

	private static SceneController instance;

	// nullの場合自分自身のインスタンスを生成nullでなければ最初に格納した同じインスタンスを使う
	public static SceneController Instance {
		get {
			if (instance == null) {
				instance = (SceneController)FindObjectOfType (typeof(SceneController));

				if (instance == null) {
					Debug.LogError (typeof(SceneController) + "is nothing");
				}
			}
			return instance;
		}
	}

	#endregion Singleton
	
	/// <summary>
	/// フェードイン・フェードアウトする黒テクスチャ
	/// </summary>
	Texture2D blackTexture;
	/// <summary>
	/// アルファ値
	/// </summary>
	float alpha = 0;
	/// <summary>
	/// フェード中かどうか
	/// </summary>
	bool isFading = false;
	/// <summary>
	/// フェードする色
	/// </summary>
	public Color fadeColor = Color.black;

	public void Awake () {

		if (this != Instance) {
			Destroy (this.gameObject);
			return;
		}
		
		// シーンが遷移した後も自身のゲームオブジェクトを破棄しない
		DontDestroyOnLoad (this.gameObject);
	}

	public void OnGUI (){
		// Fade
		if (this.isFading) {
			//色と透明度を更新して白テクスチャを描画 .
			this.fadeColor.a = this.alpha;
			GUI.color = this.fadeColor;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
		}	
	}

	/// <summary>
	/// シーンの読み込みを行う
	/// </summary>
	/// <returns><c>true</c>, if load was scened, <c>false</c> otherwise.</returns>
	/// <param name="sceneName">遷移するシーンの名前</param>
	/// <param name="fadeTime">フェードする時間</param>
	public void SceneLoad(string sceneName, float fadeTime) {
		StartCoroutine (TransScene (sceneName, fadeTime));
	}

	/// <summary>
	/// シーン遷移コルーチン
	/// </summary>
	/// <returns>The scene.</returns>
	/// <param name="sceneName">遷移するシーンの名前</param>
	/// <param name="fadeTime">フェードする時間</param>
	private IEnumerator TransScene(string sceneName, float fadeTime){
		//だんだん暗く .
		this.isFading = true;
		float time = 0;
		while (time <= fadeTime) {
			this.alpha = Mathf.Lerp (0f, 1f, time / fadeTime);      
			time += Time.deltaTime;
			yield return 0;
		}

		//シーン切替 .
		SceneManager.LoadScene (sceneName);

		//だんだん明るく .
		time = 0;
		while (time <= fadeTime) {
			this.alpha = Mathf.Lerp (1f, 0f, time / fadeTime);
			time += Time.deltaTime;
			yield return 0;
		}

		this.isFading = false;
	}
}