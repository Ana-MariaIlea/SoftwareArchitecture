using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ShopListView : MonoBehaviour
{
    public ShopModel ShopModel => shopModel; //A getter to access shopModel.

    [SerializeField]
    private VerticalLayoutGroup verticalLayoutGroup;

    [SerializeField]
    private GameObject itemPrefab; //A prefab to display an item in the view

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private TextMeshProUGUI instructionText;

    private ViewConfig viewConfig; //To set up the grid view, we need to know how many columns the grid view has, in the current setup,
                                   //this information can be found in a ViewConfig scriptable object, which serves as a configuration file for
                                   //views.

    public ShopModel shopModel; //Model in MVC pattern
    [HideInInspector]
    public ShopController shopController; //Controller in MVC pattern


    protected void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.GRIDSCREENCHANGE, ScreenChange);
        shopModel = new BuyModel(2f, 16, 500); //Right now use magic values to set up the shop
        shopController = gameObject.AddComponent<MouseController>().Initialize(shopModel);//Set the default controller to be the mouse controller
        viewConfig = Resources.Load<ViewConfig>("ViewConfig");//Load the ViewConfig scriptable object from the Resources folder
        Debug.Assert(viewConfig != null);
       // SetupItemIconView(); //Setup the grid view's properties
        PopulateItemIconView(); //Display items
        InitializeButtons(); //Connect the buttons to the controller


    }

    public abstract void OnShowInvetory(EventData eventData);
    //{
    //    LoadShopInventory e = eventData as LoadShopInventory;

    //    shopModel = e.model;
    //    shopController.Initialize(shopModel);
    //    RepopulateItemIconView();
    //}


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  RepopulateItems()
    //------------------------------------------------------------------------------------------------------------------------        
    //Clears the grid view and repopulates it with new icons (updates the visible icons)
    public void RepopulateItemIconView()
    {
        ClearIconView();
        PopulateItemIconView();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  PopulateItems()
    //------------------------------------------------------------------------------------------------------------------------        
    //Adds one icon for each item in the shop
    public void PopulateItemIconView()
    {
        foreach (MyItem item in shopModel.myInventory.GetItems())
        {
            AddItemToView(item);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  PopulateItemsByType()
    //------------------------------------------------------------------------------------------------------------------------        
    //Adds one icon for each item in the shop
    public void PopulateItemIconViewByType(TypeOfItem typeOfItem)
    {
        foreach (MyItem item in shopModel.myInventory.GetItems())
        {
            if (item.type == typeOfItem)
                AddItemToView(item);
        }
    }



    //------------------------------------------------------------------------------------------------------------------------
    //                                                  ClearIconView()
    //------------------------------------------------------------------------------------------------------------------------        
    //Removes all existing icons in the gridview
    public void ClearIconView()
    {
        Transform[] allIcons = verticalLayoutGroup.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allIcons)
        {
            if (child != verticalLayoutGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  AddItemToView()
    //------------------------------------------------------------------------------------------------------------------------        
    //Adds a new item container to the view, each view can have its way of displaying items
    public void AddItemToView(MyItem item)
    {
        GameObject newItemIcon = GameObject.Instantiate(itemPrefab);
        newItemIcon.transform.SetParent(verticalLayoutGroup.transform);
        newItemIcon.transform.localScale = Vector3.one;//The scale would automatically change in Unity so we set it back to Vector3.one.

        
        ListViewItemContainer itemContainer = newItemIcon.GetComponent<ListViewItemContainer>();
        Debug.Assert(itemContainer != null);
        bool isSelected = (item == shopModel.GetSelectedItem());
        itemContainer.Initialize(item, isSelected);
    }
    //------------------------------------------------------------------------------------------------------------------------
    //                                                  UpdateInfoPannel()
    //------------------------------------------------------------------------------------------------------------------------ 
    public void UpdateInfoPannel()
    {

    }
    //------------------------------------------------------------------------------------------------------------------------
    //                                                  InitializeButtons()
    //------------------------------------------------------------------------------------------------------------------------        
    //This method adds a listener to the 'Buy' button. They are forwarded to the controller. Since this is the confirm button of
    //the buy view, it will just call the controller interface's ConfirmSelectedItem function, the controller will handle the rest.
    public void InitializeButtons()
    {
        buyButton.onClick.AddListener(
            delegate
            {
                shopController.ConfirmSelectedItem();
            }
        );
    }

    public void ScreenChange(EventData eventData)
    {
        RepopulateItemIconView();
    }
    private void Update()
    {
        // RepopulateItemIconView();//Repopulate the view each frame, this is very inefficient and won't work in many scenarios and SHOULD NOT be in
        //the final implementation, the view should be modified by the models via an observer or event queue pattern

        //Switch between mouse and keyboard controllers
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (shopController is MouseController)
            {
                SwitchToKeyboardControl();
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (shopController is GridViewKeyboardController)
            {
                SwitchToMouseControl();
            }
        }

        //Let the current controller handle input
        shopController.HandleInput();
    }


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  SwitchToKeyboardControl()
    //------------------------------------------------------------------------------------------------------------------------    
    private void SwitchToKeyboardControl()
    {
        Destroy(shopController);//Remove the current controller component
        shopController = gameObject.AddComponent<GridViewKeyboardController>().Initialize(shopModel);//Create and add a keyboard controller
        instructionText.text = "The current control mode is: Keyboard Control, WASD to select item, press K to buy. Press left mouse button to switch to Mouse Control.";
        buyButton.gameObject.SetActive(false);//Hide the buy button because we only use keyboard
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  SwitchToMouseControl()
    //------------------------------------------------------------------------------------------------------------------------ 
    private void SwitchToMouseControl()
    {
        Destroy(shopController);//Remove the current controller component
        shopController = gameObject.AddComponent<MouseController>().Initialize(shopModel);//Create and add a mouse controller
        instructionText.text = "The current control mode is: Mouse Control, press 'K' to switch to Keyboard Control.";
        buyButton.gameObject.SetActive(true);//Show the buy button for the mouse controler
    }
}
