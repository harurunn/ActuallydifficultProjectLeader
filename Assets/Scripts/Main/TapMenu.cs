///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// メニューバーを開く三角を押した時の処理
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapMenu : MonoBehaviour {

	/// <summary>
	/// メニューの表示非表示を行う矢印
	/// </summary>
	[SerializeField]
	Text clickText;
	/// <summary>
	/// 表示非表示のアニメーションをさせるオブジェクト
	/// </summary>
	[SerializeField]
	GameObject menuPanel;

	bool panelState = false;

	void Start(){
		EventTrigger trigger = clickText.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry ();

		MenuBarMotion mb = menuPanel.GetComponent<MenuBarMotion> ();

		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener ( (x) => {
			if(!panelState){
				panelState = !panelState;
				mb.SlideIn();	
			} else{
				panelState = !panelState;
				mb.SlideOut();
			}
		});
		trigger.triggers.Add (entry);
	}
}