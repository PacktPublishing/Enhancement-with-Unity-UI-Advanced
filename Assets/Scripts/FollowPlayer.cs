using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public Vector3 offset = new Vector3(0,1.5f,0);

    void Update() {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * 5f);
    }
	
}
