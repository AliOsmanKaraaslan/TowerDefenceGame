using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {
    private Camera mainCamera;
    private BuildingTypeSO buildingType;
    private BuildingTypeListSO buildingTypeList;
    private void Awake() { 
        buildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingTypeList");
        buildingType = buildingTypeList.list[0];
    }

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.T)) {
            buildingType = buildingTypeList.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            buildingType = buildingTypeList.list[1];
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
