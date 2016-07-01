using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ProcessInputSystem : IReactiveSystem {

    public TriggerOnEvent trigger {
        get { return Matcher.Input.OnEntityAdded(); }
    }

    public void Execute(List<Entity> entities) {
        Debug.Log("Process input");
    }
}