using UnityEngine;

public class Wall : MonoBehaviour
{
    public TextMesh QuestTxt;
    public int NeedApples;

    private void Awake()
    {
        QuestTxt.text = NeedApples.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
        {
            NeedApples -= inventory.ApplesRemoveCount();
            QuestTxt.text = NeedApples.ToString();

            inventory.RemoveApplesFromInventory();

            if (NeedApples <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
