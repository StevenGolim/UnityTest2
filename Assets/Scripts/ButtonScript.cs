using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ButtonScript : MonoBehaviour {

    [SerializeField] Button button;
    [SerializeField] int num_button = 10;

    private static int num_red ;
    private static int num_blue;

    void Awake()
    {
        num_red = 0;
        num_blue = 0;
    }
    // Use this for initialization
    void Start()  {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickClone()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    public void OnClickCreate()
    {
        GameObject Content;
        Content = GameObject.Find("Content");
        if (EventSystem.current.currentSelectedGameObject.name == "RedButton")
        {
            GameObject new_button = (GameObject)Instantiate(Resources.Load("RedButton"));
            new_button.name = "赤ボタン " + (num_red + 1);
            new_button.GetComponentInChildren<Text>().text = "赤ボタン " + (num_red + 1);
            num_red += 1;
            new_button.transform.SetParent(Content.transform, false);
            new_button.GetComponent<Button>().onClick.AddListener(OnClickClone);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "BlueButton")
        {
            GameObject new_button = (GameObject)Instantiate(Resources.Load("BlueButton"));
            new_button.name = "青ボタン " + (num_blue + 1);
            new_button.GetComponentInChildren<Text>().text = "青ボタン " + (num_blue + 1);
            num_blue += 1;
            new_button.transform.SetParent(Content.transform, false);
            new_button.GetComponent<Button>().onClick.AddListener(OnClickClone);
        }


    }
}
