using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapMenu : MonoBehaviour {

	[SerializeField]
	Text ClickText;

	public void onTap(){
		MenuBarMotion mb = new MenuBarMotion ();
		mb.SlideIn ();
	}

	void Start(){
		EventTrigger trigger = ClickText.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry ();

		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener ( (x) => {
			Debug.Log ("Clicked");
		});
		trigger.triggers.Add (entry);
	}
}
