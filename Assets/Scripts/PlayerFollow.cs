using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
    }
}
