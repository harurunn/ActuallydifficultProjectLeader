///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// メッセージボックス内のテキストを制御するクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	/// <summary>
	/// テキストの表示間隔
	/// </summary>
	[SerializeField][Range(0.001f, 0.3f)]
	public float intervalForCharacterDisplay = 0.05f;

	[SerializeField]
	Text uiText;

	/// <summary>
	/// 表示中の文字
	/// </summary>
	string currentText;
	/// <summary>
	/// 表示までの時間
	/// </summary>
	float timeUntilDisplay;
	/// <summary>
	/// 時間経過
	/// </summary>
	float timeElapsed = 1;
	/// <summary>
	/// 最後に更新された文字
	/// </summary>
	int lastUpdateCharacter = -1;

	// 表示が完了しているかどうか
	public bool IsCompleteDisplayText {
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	// 強制的に全文表示する
	public void ForceCompleteDisplayText () {
		timeUntilDisplay = 0;
	}

	// 次に表示する文字列をセットする
	public void SetNextLine(string text) {
		currentText = text;
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		lastUpdateCharacter = -1;
	}

	void Update () {
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}
}
