using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    public float damage = 15f;
    public GameObject indicatorPrefab;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.SendMessage("HitBack", transform);
            other.gameObject.SendMessage("TakeDamage", damage);
            GameObject go = (GameObject)Instantiate(
                indicatorPrefab, 
                other.gameObject.transform.position, 
                new Quaternion()
            );
            go.GetComponent<DamageIndicator>().label.text = "-" + damage.ToString("F0");
        }
    }
}
