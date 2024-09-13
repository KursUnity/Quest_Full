using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] Images;
    public Sprite EmptySprite;
    public Sprite AppleSprite;

    private int _applesCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Food food))
        {
            SpriteRenderer foodSprite = food.GetComponent<SpriteRenderer>();

            foreach (var img in Images)
            {
                if (img.sprite == EmptySprite)
                {
                    img.sprite = foodSprite.sprite;
                    Destroy(collision.gameObject);

                    if (img.sprite == AppleSprite)
                    {
                        _applesCount++;
                    }

                    return;
                }
            }
        }
    }

    public int ApplesRemoveCount()
    {
        return _applesCount;
    }

    public void RemoveApplesFromInventory()
    {
        foreach (var img in Images)
        {
            if (img.sprite == AppleSprite)
            {
                if (_applesCount > 0)
                {
                    _applesCount--;
                    img.sprite = EmptySprite;
                }
            }
        }
    }
}
