using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBlock : MonoBehaviour, IDropHandler {
    public Transform currentItem {
        get {
            if (transform.childCount > 0) {
                return transform.GetChild(0);
            } else return null;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        if(currentItem == null) {
            Debug.Log("Dropped on me");
            InventoryItem.currentItem.transform.SetParent(transform);
            InventoryItem.currentItem.transform.localPosition = Vector3.zero;
        }
    }
}
