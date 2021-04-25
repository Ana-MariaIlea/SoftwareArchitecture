using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using TMPro;

/// <summary>
/// This class is applied to a button that represents an Item in the View. It is a visual representation of the item
/// when it is visible in the store. The class holds a link to the original Item, it sets the icon of the button to
/// the one specified in the Item data, and it enables or disables the infoPanel to indicate if the item is selected
/// and display the details of the item.
/// </summary>
public class GridViewItemContainer : MonoBehaviour, IItemContainer
{
    public Item Item => item;//Public getter for the item, required by IItemContainer interface.

    public MyItem Itemm => itemm;


    //Link to the highlight image (set in prefab)
    [SerializeField]
    private GameObject highLight;

    //Link to the infomation panel (set in prefab)
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI category;
    [SerializeField]
    private TextMeshProUGUI money;
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
    public void Initialize(MyItem item, bool isSelected) {
        //Stores the item
        this.itemm = item;

        //Sets the highlight image and infoPanel's visibility
        if (isSelected) {
            highLight.SetActive(true);
            infoPanel.SetActive(true);
        }

        // Clones the first Sprite in the icon atlas that matches the iconName and uses it as the sprite of the icon image.
        Sprite sprite = iconAtlas.GetSprite(item.iconName);

        if (sprite != null) {
            icon.sprite = sprite;
        }

        name.text = item.name;
        money.text = item.price.ToString();
        switch (item.type)
        {
            case TypeOfItem.Armor:
                category.text = "Armor";
                ArmorItem a = item as ArmorItem;
                atributes.text = "Defence Physical " + a.PhysicalDamageReduction+"\nDefence Elemental " + a.ElementalDamageReduction + "\nStamina increase " + a.StaminIncrease;
                break;
            case TypeOfItem.Weapon:
                WeaponItem w = item as WeaponItem;
                atributes.text = "Physical Attack " + w.PhysicalAttack + "\nElemental Attack " + w.ElementalAttack + "\nDamage Reduced When Bock " + w.DamageReducedWhenBock;
                category.text = "Weapon";
                break;
            case TypeOfItem.Potion:
                PotionItem p = item as PotionItem;
                atributes.text = "Health Change " + p.HealthChange + "\nStamina Change " + p.StaminaChange + "\nDuration " + p.EffectTime;
                category.text = "Potion";
                break;
        }
    }
}
