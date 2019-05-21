using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChatDialog : MonoBehaviour {
    public static ChatDialog Instance = null;

    public GameObject dialog;
    public Text chatText;
    public Text charName;
    public Image charImage;
    public Text confirmText;
    public Text cancelText;
    public Button confirmBtn;


    void Start() {
        Instance = this;
        HideDialog();
    }
    
    public void SetDialog(ChatObject c) {
        ShowDialog();
        chatText.text = c.chatText;
        charName.text = c.characterName;
        charImage.sprite = c.characterSprite;
        charImage.preserveAspect = true;
        confirmText.text = c.confirmText;
        cancelText.text = c.cancelText;
        confirmBtn.onClick.RemoveAllListeners();
        confirmBtn.onClick.AddListener(c.confirmEvent.Invoke);
    }

    public void HideDialog() {
        dialog.SetActive(false);
    }

    public void ShowDialog() {
        dialog.SetActive(true);
    }
	
}

[System.Serializable]
public class ChatObject {
    public string chatText;
    public string characterName;
    public Sprite characterSprite;
    public string confirmText;
    public string cancelText;
    public UnityEvent confirmEvent;
}
