using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour {

    public Button button;
    int num_button = 10;

	// Use this for initialization
	void Start () {
		for(int i = 0; i< num_button; i++)
        {
            Button new_button = (Button)Instantiate(button);
            new_button.transform.position = new Vector3(0, 150 - (i * 33), 0);
            new_button.name = "ボタン " + (i+1);
            new_button.GetComponentInChildren<Text>().text = "ボタン "+ (i+1) ; 
            new_button.transform.SetParent(gameObject.transform, false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
