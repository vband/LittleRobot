using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouDiedScreen : MonoBehaviour 
{
	[SerializeField]
	private Text text;

	void Start()
	{
		if (!text) text = GetComponent<Text>();
		text.enabled = false;
	
		GameManager.Instance.player.onDied += () => 
		{
			text.enabled = true;
        	Time.timeScale = 0;
		};
	}
}
