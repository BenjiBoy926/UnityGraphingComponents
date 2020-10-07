using UnityEngine;

public class GameObjectsEqual : Function<bool>
{
    public Input<GameObject> gameObject1;
    public Input<GameObject> gameObject2;

    public override bool Get()
    {
        return gameObject1.value == gameObject2.value;
    }
}
