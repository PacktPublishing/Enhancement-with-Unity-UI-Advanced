﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public DialogObject dialog;
    public GameObject buttonPrompt;

    bool canInteract = false;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            buttonPrompt.SetActive(true);
            canInteract = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            buttonPrompt.SetActive(false);
            canInteract = false;
        }
    }

    void Update() {
        if(canInteract && Input.GetKeyDown(KeyCode.E)) {
            ModalDialog.Instance.gameObject.SetActive(true);
            ModalDialog.Instance.SetDialog(dialog);
            buttonPrompt.SetActive(false);
            canInteract = false;
        }
    }

}
