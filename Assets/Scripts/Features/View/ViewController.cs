using UnityEngine;

public class ViewController : MonoBehaviour {
    public Vector3 position {
        get { return this.transform.position; }
        set { this.transform.localPosition = value; }
    }
}
