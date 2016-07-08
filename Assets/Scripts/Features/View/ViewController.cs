using DG.Tweening;
using UnityEngine;

public interface IViewController {

    Vector3 position { get; set; }

    void Move(Vector3 position, float durationInSeconds);
    void Despawn();
}

public class ViewController : MonoBehaviour, IViewController {
    public Vector3 position {
        get { return this.transform.position; }
        set { this.transform.localPosition = value; }
    }

    public void Despawn() {
        this.gameObject.Unlink();
        Destroy(this.gameObject);
    }

    public void Move(Vector3 position, float durationInSeconds) {
        this.transform.DOMove(position, durationInSeconds);
    }
}
