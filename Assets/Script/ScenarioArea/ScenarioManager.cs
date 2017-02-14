///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// シナリオの管理を行うクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class ScenarioManager : MonoBehaviour{

	TextController textController;
	CommandController commandController;

	/// <summary>
	/// シナリオを順番に格納したもの
	/// </summary>
	public string[] ScenarioList;
	/// <summary>
	/// 現在のテキストが格納されている配列の番号
	/// </summary>
	int index;
	/// <summary>
	/// Preloadコマンドが呼ばれたかどうか
	/// </summary>
	bool isCallPreload;
	/// <summary>
	/// 読み込むシナリオファイルの名前
	/// </summary>
	public string loadFileName = "notProgress";

	/// <summary>
	/// 次のメッセージを読み込む
	/// </summary>
	void RequestNextLine () {
		var currentText = ScenarioList[index];
		textController.SetNextLine (CommandCheck(currentText));
		index++;
		isCallPreload = false;
	}

	/// <summary>
	/// テキストファイルからシナリオを読み込むメソッド
	/// 引数として読み込むシナリオファイルの名前を与える
	/// </summary>
	/// <param name="filename">Filename.</param>
	public void UpdateLines (string filename) {
		// テキストファイルから読み込んだシナリオテキスト
		var ScenarioTexe = Resources.Load <TextAsset>("Scenario/" + filename);

		if (ScenarioTexe == null) {
			Debug.LogError (filename);
			Debug.LogError ("シナリオファイルが見つかりませんでした。");
			enabled = false;
			return;
		}
		// @brで区切った文字列をリストに代入する
		// StringSplitOptions.Noneは@brが隣接した場合空の文字列でもリストに追加する
		ScenarioList = ScenarioTexe.text.Split (new string[]{"@br"}, System.StringSplitOptions.None);

		// インデックスの初期化
		index = 0;

		// シナリオを入れたグローバル関数の破棄
		Resources.UnloadAsset (ScenarioTexe);
	}

	/// <summary>
	/// 表示する文字列にコマンド（＠）が含まれているか
	/// 含まれていない文字は連結を行う
	/// </summary>
	/// <param name="text">Text.</param>
	public string CommandCheck(string message) {

		// １行ずつ読み込む
		var lineReader = new StringReader(message);
		// 内容の変更を行える文字列
		var lineBuilder = new StringBuilder ();
		var text = "";

		// テキストボックスに表示するメッセージを１行ずつnullになるまで実行
		while ((text = lineReader.ReadLine()) != null) {

			// コメントアウトを検索する
			var commentCharacterCount = text.IndexOf("//");
			/* コメントアウトが見つかった場合、
			 	メッセージの最初からコメントアウトの部分までをtextに代入 */
			if (commentCharacterCount != -1) {
				text = text.Substring(0, commentCharacterCount );
			}
			// 代入されたテキストが空配列またはnullじゃない場合文字列連結を行う
			if (!string.IsNullOrEmpty (text)) {
				// １行ずつ読み込んだテキストの始まりが＠マークの場合文字列連結を行わずにifを抜ける
				if (text [0] == '@' && commandController.LoadCommand(text))
					continue;
				lineBuilder.AppendLine (text);
			}
		}
		return lineBuilder.ToString ();
	}

	void Start () {
		textController = GetComponent<TextController>();
		commandController = GetComponent<CommandController>();

		UpdateLines(loadFileName);
		RequestNextLine();
	}

	void Update () {
		if(textController.IsCompleteDisplayText ) {
			if(index < ScenarioList.Length) {
				if( !isCallPreload ) {
					commandController.PreLoadCommand(ScenarioList[index]);
					isCallPreload = true;
				}
				if( Input.GetMouseButtonDown(0)) {
					RequestNextLine();
				}
			}
		}else{
			if(Input.GetMouseButtonDown(0)) {
				textController.ForceCompleteDisplayText();
			}
		}
	}
}
