using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour {

    public Text label;

    void Start() {
        label = GetComponentInChildren<Text>();
    }
    
    void Update() {
        transform.LookAt(Camera.main.transform);
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }
	
}
