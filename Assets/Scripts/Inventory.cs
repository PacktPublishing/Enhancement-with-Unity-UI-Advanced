using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory Instance = null;

    public GameObject inventoryWindow;
    public GameObject[] grid;
    public GameObject itemPrefab;

    void Awake() {
        Instance = this;
    }

    void Start() {
        HideInventory();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (inventoryWindow.activeSelf) {
                HideInventory();
            } else {
                ShowInventory();
            }
        }
    }

    public void SetItems(List<Item> items) {
        for(int i = 0; i < items.Count; i++) {
            GameObject go = Instantiate(itemPrefab, grid[i].transform);
            go.GetComponent<InventoryItem>().SetItem(items[i]);
        }
    }

    public void ShowInventory() {
        inventoryWindow.SetActive(true);
    }

    public void HideInventory() {
        inventoryWindow.SetActive(false);
    }

}
