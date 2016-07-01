using System;
using UnityEngine;

/// <summary>
/// Camera component that is responsible for resizing of camera based on the size of the board
/// </summary>
[RequireComponent(typeof(Camera))]
public class LevelRunCameraController : MonoBehaviour {

    private Camera levelCamera;

    public void Awake() {
        this.levelCamera = this.GetComponent<Camera>();
        if (!this.levelCamera.orthographic) {
            throw new InvalidOperationException("The camera should be set to orthographic");
        }
    }

    public void Start() {
    }

    public void Initialize(GameBoardComponent gameBoard) {
        if (gameBoard == null) {
            throw new ArgumentNullException("gameBoard");
        }

        float widthWorldSpace = gameBoard.columnCount;
        float heightWorldSpace = gameBoard.rowCount;
        float heightCameraSize = heightWorldSpace * 0.5f * (1 + Constants.LevelRun.HeaderAndFooterScreenSizePercentage);
        float widthCameraSize = (widthWorldSpace * 0.5f) / this.levelCamera.aspect;
        this.levelCamera.orthographicSize = Mathf.Max(heightCameraSize, widthCameraSize);
        Vector3 cameraPosition = new Vector3((gameBoard.columnCount - 1f) * 0.5f, (gameBoard.rowCount - 1f) * 0.5f, this.levelCamera.transform.position.z);
        this.levelCamera.transform.position = cameraPosition;
    }
}
