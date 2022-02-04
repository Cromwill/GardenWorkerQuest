using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("_PositionMoving", transform.position);
    }
}
