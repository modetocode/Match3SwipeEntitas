using Entitas;
using UnityEngine;

/// <summary>
/// Responsible for handling input.
/// </summary>
public class InputController : MonoBehaviour {

    private int touchFingerId = -1;
    private GameObject lastObjectTouchHit = null;

    private Pool InputPool { get { return Pools.pool; } }

    public void Update() {
        this.HandleTouchInput();
    }

    private void HandleTouchInput() {
        for (int i = 0; i < Input.touches.Length; i++) {
            Touch currentTouch = Input.touches[i];

            // Only one finger will be tracked; If the player has already put a finger on the screen the other fingers will be unregistered
            if (currentTouch.phase == TouchPhase.Began && touchFingerId == -1) {
                touchFingerId = currentTouch.fingerId;
                this.InputPool.isTouchInProgress = true;
            }

            if (touchFingerId != currentTouch.fingerId) {
                continue;
            }

            if (currentTouch.phase == TouchPhase.Stationary) {
                continue;
            }

            if (currentTouch.phase == TouchPhase.Canceled) {
                this.touchFingerId = -1;
                this.lastObjectTouchHit = null;
                continue;
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100)) {
                GameObject hitObject = hit.collider.gameObject;
                if (!hitObject.Equals(this.lastObjectTouchHit)) {
                    this.InputPool.CreateEntity().AddObjectSelectedInput(hitObject);
                    this.lastObjectTouchHit = hitObject;
                }

            }

            if (currentTouch.phase == TouchPhase.Ended) {
                this.touchFingerId = -1;
                this.lastObjectTouchHit = null;
                this.InputPool.isTouchInProgress = false;
            }
        }
    }
}
