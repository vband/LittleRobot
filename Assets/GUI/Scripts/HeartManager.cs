using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform heartPrefab;

    private int numberOfHearts = 5;

	void Start ()
    {
		GameManager.Instance.player.onAttacked += () => HandleHearts();
	}
	
    
    public void HandleHearts()
    {
        while (numberOfHearts > (int)GameManager.Instance.player.CurrentLife)
        {
            numberOfHearts--;
            Destroy(GetComponentInChildren<Image>().gameObject);
        }

        while (numberOfHearts < (int)GameManager.Instance.player.CurrentLife)
        {
            numberOfHearts++;
            Instantiate(heartPrefab, transform);
        }
    }
}
