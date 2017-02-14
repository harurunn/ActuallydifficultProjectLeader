///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// Title画面からSelect画面への遷移を行うクラス
///////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneChangeSelect : MonoBehaviour {

	/// <summary>
	/// TitleからSelect画面に遷移するメソッド
	/// </summary>
	public void SceneChange(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Main");
	}
}
