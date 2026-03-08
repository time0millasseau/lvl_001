using UnityEngine;

public class LightFollow : MonoBehaviour
{
  public Transform player;
        void Update()
    {
        transform.position = player.position;
    }
}
