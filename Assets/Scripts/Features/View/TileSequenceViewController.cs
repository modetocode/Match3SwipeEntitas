using Entitas;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TileSequenceViewController : ViewController {
    private LineRenderer lineRenderer;

    public void Awake() {
        this.lineRenderer = this.GetComponent<LineRenderer>();
    }

    public void DrawSequence(IList<Entity> sequence) {
        this.lineRenderer.SetVertexCount(sequence.Count);
        for (int i = 0; i < sequence.Count; i++) {
            Vector3 position = sequence[i].view.controller.position;
            this.lineRenderer.SetPosition(i, position);
        }
    }
}
