using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public enum ItemType
    {
        Path, Block
    }

    public ItemType gridType;
    private bool isActive = false;
    private SpriteRenderer theSprite;
    private LevelContorller theLevel;

    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
        theLevel = FindObjectOfType<LevelContorller>();
        InitGridType();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isActive)
                ActiveGrid();
        }
    }

    void ActiveGrid()
    {
        isActive = true;
        // theSprite.color = Color.green;
        theSprite.color = new Color(141.0f / 255.0f, 185.0f / 255.0f, 255 / 255);
        theLevel.RemoveGridFromList(this);
        theLevel.CheckWin();
    }

    void InitGridType()
    {
        switch (gridType)
        {
            case ItemType.Path:
                GetComponent<Collider2D>().isTrigger = true;
                theSprite.color = Color.white;
                break;
            case ItemType.Block:
                GetComponent<Collider2D>().isTrigger = false;
                theSprite.color = Color.gray;
                theLevel.RemoveGridFromList(this);
                isActive = true;
                break;
        }
    }
}
