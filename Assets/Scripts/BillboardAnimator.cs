using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillboardAnimator : MonoBehaviour {

    public Animator anim;
    public Text label;


    public void SetOn() {
        anim.SetBool("On", true);
        label.text = "ON";
    }

    public void SetOff() {
        anim.SetBool("On", false);
        label.text = "OFF";
    }
}
