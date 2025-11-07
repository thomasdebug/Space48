using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    [SerializeField] private TMP_Text messageField;

    private List<Color> items = new();
    private int activeItemIndex = -1;
    private Movement shipMovement;
    private Shooting shipShooting;
    private UI shipUI;

    private void Start()
    {
        shipMovement = GetComponent<Movement>();
        shipShooting = GetComponent<Shooting>();
        shipUI = GetComponent<UI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }

    private void PickUpItem(GameObject item)
    {
        Color color = item.GetComponent<Renderer>().material.color;
        Destroy(item);

        items.Add(color);
        activeItemIndex = items.Count - 1;

        itemImageHolder.color = color;
        itemImageHolder.enabled = true;
    }

    void Update()
    {
        CycleItems();
        UseItem();
    }

    private void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count == 0)
            {
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
                return;
            }

            activeItemIndex = (activeItemIndex + 1) % items.Count;
            itemImageHolder.color = items[activeItemIndex];
        }
    }

    private void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {
            Color activeColor = items[activeItemIndex];

            if (activeColor == Color.blue)
            {
                shipUI.ShowMessage("+ Move Speed");
                shipMovement.MoveSpeed += 5f;
            }
            else if (activeColor == Color.red)
            {
                shipUI.ShowMessage("+ Fire Rate");
                shipShooting.ImproveFireRate(0.1f);
            }
            else if (activeColor == Color.green)
            {
                shipUI.ShowMessage("+ Rotation Speed");
                shipMovement.RotationSpeed += 10f;
            }

            items.RemoveAt(activeItemIndex);
            if (items.Count == 0)
            {
                itemImageHolder.enabled = false;
                activeItemIndex = -1;
            }
            else
            {
                activeItemIndex = Mathf.Clamp(activeItemIndex, 0, items.Count - 1);
                itemImageHolder.color = items[activeItemIndex];
            }
        }
    }
}
