using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using TMPro;

public class ListViewItemContainer : MonoBehaviour, IItemContainer
{
    public Item Item => item;//Public getter for the item, required by IItemContainer interface.

    public MyItem Itemm => itemm;

    [SerializeField]
    private GameObject highLight;
    //Link to the infomation panel (set in prefab)
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private TextMeshProUGUI nameRow;
    [SerializeField]
    private TextMeshProUGUI nameInfoPanel;
    [SerializeField]
    private TextMeshProUGUI categoryRow;
    [SerializeField]
    private TextMeshProUGUI moneyRow;
    [SerializeField]
    private TextMeshProUGUI atributes;

    [SerializeField]
    private Image icon;

    //Link to the atlas of all the item icons, use to retrieve sprites for items. For more information of the API check:
    // https://docs.unity3d.com/2019.3/Documentation/Manual/class-SpriteAtlas.html
    [SerializeField]
    private SpriteAtlas iconAtlas;

    //link to the original item (set in Initialize)
    private Item item;
    private MyItem itemm;

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  Initialize()
    //------------------------------------------------------------------------------------------------------------------------
    public void Initialize(MyItem item, bool isSelected)
    {
        //Stores the item
        this.itemm = item;

        //Sets the highlight image and infoPanel's visibility
        if (isSelected)
        {
            highLight.SetActive(true);
            infoPanel.SetActive(true);
        }

        // Clones the first Sprite in the icon atlas that matches the iconName and uses it as the sprite of the icon image.
        Sprite sprite = iconAtlas.GetSprite(item.iconName);

        if (sprite != null)
        {
            icon.sprite = sprite;
        }

        nameRow.text = item.name;
        nameInfoPanel.text = item.name;
        moneyRow.text = item.price.ToString();
        switch (item.type)
        {
            case TypeOfItem.Armor:
                categoryRow.text = "Armor";
                ArmorItem a = item as ArmorItem;
                atributes.text = "Defence " + a.ElementalDamageReduction;
                break;
            case TypeOfItem.Weapon:
                WeaponItem w = item as WeaponItem;
                atributes.text = "Block damage " + w.DamageReducedWhenBock;
                categoryRow.text = "Weapon";
                break;
            case TypeOfItem.Potion:
                PotionItem p = item as PotionItem;
                atributes.text = "Health " + p.HealthChange;
                categoryRow.text = "Potion";
                break;
        }
    }
}