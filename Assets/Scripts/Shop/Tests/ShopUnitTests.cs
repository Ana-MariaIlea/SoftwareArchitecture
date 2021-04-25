using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class ShopUnitTests
    {
        private ShopGridBuyView gridBuyView;//This is the grid buy view we want to test
        private ShopGridSellView gridSellView;//This is the grid buy view we want to test
        private ShopGridUpgradeView gridUpgradeView;//This is the grid buy view we want to test

        private ShopListBuyView listBuyView;//This is the grid buy view we want to test
        private ShopListSellView listSellView;//This is the grid buy view we want to test
        private ShopListUpgradeView listUpgradeView;//This is the grid buy view we want to test

        private Player player;
        private Shop shop;

        //Setup the test scene
        [OneTimeSetUp]
        public void LoadShopScene()
        {
            // Load the Scene to do unit test. In the scope of this project, this is fine. In a more complicated project, a game scene could take
            // a long time to load, in which case it's better to create test scenes to do unit tests
            SceneManager.LoadScene(0);
        }

        //Setup the unit tests here
        [UnitySetUp]
        public IEnumerator SetupTests()
        {
            yield return null; //yield return null skips one frame, this is to make sure that this happens after the scene is loaded

            //The shop scene only contains one grid buy view, we use Resources.FindObjectsOfTypeAll to get the reference to it,
            //Resources.FFindObjectsOfTypeAll is used instead of GameObject.Find because the later can't find disabled objects
            gridBuyView = Resources.FindObjectsOfTypeAll<ShopGridBuyView>()[0];
            gridSellView = Resources.FindObjectsOfTypeAll<ShopGridSellView>()[0];
            gridUpgradeView = Resources.FindObjectsOfTypeAll<ShopGridUpgradeView>()[0];

            listBuyView = Resources.FindObjectsOfTypeAll<ShopListBuyView>()[0];
            listSellView = Resources.FindObjectsOfTypeAll<ShopListSellView>()[0];
            listUpgradeView = Resources.FindObjectsOfTypeAll<ShopListUpgradeView>()[0];

            player = Resources.FindObjectsOfTypeAll<Player>()[0];
            shop = Resources.FindObjectsOfTypeAll<Shop>()[0];

            //Active the gridBuyView game object to initialize the class, if we don't do this 'void Start()' won't be called
            //You should active all the game objects that are involved in the test before testing the functions from their components
            player.gameObject.SetActive(true);
            shop.gameObject.SetActive(true);

            gridBuyView.gameObject.SetActive(true);
            gridSellView.gameObject.SetActive(true);
            gridUpgradeView.gameObject.SetActive(true);

            listBuyView.gameObject.SetActive(true);
            listSellView.gameObject.SetActive(true);
            listUpgradeView.gameObject.SetActive(true);
        }
        [UnityTest]
        public IEnumerator EventQueueInstanceInitiated()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //now test if a eventQueue is initiated
            Assert.IsNotNull(EventQueue.eventQueue, "No eventQueue in the scene");
        }


        [UnityTest]
        public IEnumerator EventQueueThrowsExceptionsWhenPublishingAnEventWithInvalidEvetType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                EventQueue.eventQueue.AddEvent(new EventData(EventType.UNITTESTS));
                EventQueue.eventQueue.PublishEvents();
            });
        }

        [UnityTest]
        public IEnumerator EventQueueThrowsExceptionsWhenUnsubscribingWithInvalidEvetType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                EventQueue.eventQueue.UnSubscribe(EventType.STARTGAME, null);
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      Player tests
        //-------------------------------------------------------------------------------------------------------------------------------------


        [UnityTest]
        public IEnumerator PlayerShopModelInitializedShopModel()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //now test if a ShopModel is assigned to gridBuyView
            Assert.IsNotNull(player.ShopModel, "No ShopModel is assigned in Player");
        }

        [UnityTest]
        public IEnumerator PlayerShopModelThrowsExceptionsWhenOnBuyStartCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                player.OnItemBuyBegin(new EventData(EventType.UNITTESTS));
            });
        }
        public IEnumerator PlayerShopModelThrowsExceptionsWhenOnBuyEndCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                player.OnItemBuyEnd(new EventData(EventType.UNITTESTS));
            });
        }
        public IEnumerator PlayerShopModelThrowsExceptionsWhenOnSellItemCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                player.OnItemSold(new EventData(EventType.UNITTESTS));
            });
        }

        public IEnumerator PlayerShopModelThrowsExceptionsWhenOnUpgradeStartCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                player.OnItemUpgradeStart(new EventData(EventType.UNITTESTS));
            });
        }
        public IEnumerator PlayerShopModelThrowsExceptionsWhenOnUpgradeEndCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                player.OnItemUpgradeEnd(new EventData(EventType.UNITTESTS));
            });
        }


        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      Shop tests
        //-------------------------------------------------------------------------------------------------------------------------------------


        [UnityTest]
        public IEnumerator ShopShopModelInitializedShopModel()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //now test if a ShopModel is assigned to gridBuyView
            Assert.IsNotNull(shop.ShopModel, "No ShopModel is assigned in Shop");
        }
        // Use meaningful name for your test cases, this case tests if the ShopGridBuyView component has initialized its ShopModel property 
        [UnityTest]
        public IEnumerator ShopGridBuyViewInitializedShopModel()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //now test if a ShopModel is assigned to gridBuyView
            Assert.IsNotNull(gridBuyView.ShopModel, "No BuyModel is assigned in ShopGridBuyView");
        }

        public IEnumerator ShopShopModelThrowsExceptionsWhenOnItemAddedCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                shop.OnAddItemFromInventory(new EventData(EventType.UNITTESTS));
            });
        }
        public IEnumerator ShopShopModelThrowsExceptionsWhenOnItemRemovedCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                shop.OnRemoveItemFromInventory(new EventData(EventType.UNITTESTS));
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      gridBuyView tests
        //-------------------------------------------------------------------------------------------------------------------------------------

        //This case tests if the grid buy view displays the correct amount of Items
        [UnityTest]
        public IEnumerator ShopGridBuyViewDisplaysCorrectAmountOfItems()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //Now that the scene is loaded and the gridBuyView game object was activated in SetupTests(), we can use GameObject.Find
            //to find the game object we want to test
            GameObject gridItemsPanel = GameObject.Find("GridItemsPanel");

            yield return new WaitForEndOfFrame();//Since we are testing how many items are displayed, we should use WaitForEndOfFrame to wait until the end of the frame,
                                                 //so that the view finished updating and rendering everything 

            int itemCount = gridItemsPanel.transform.childCount;
            Assert.AreEqual(gridBuyView.ShopModel.myInventory.GetItemCount(), itemCount, "The generated item count is not equal to shopModel's itemCount");
        }

        [UnityTest]
        public IEnumerator ShopGridBuyViewThrowsExceptionsWhenOnLoadInventoryCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                gridBuyView.OnShowInvetory(new EventData(EventType.UNITTESTS));
            });
        }

        //This case tests if the buyModel can throw an ArgumentOutOfRangeException when it's asked to select an item by a negative
        //index. Incorrect indexes can be generated from bugs in views or controllers, throwing the correct type of exceptions is
        //better than failing silently for debugging. Your unit tests should cover exception handlings
        [UnityTest]
        public IEnumerator GridBuyViewShopModelThrowsExceptionsWhenSelectingNegativeIndex()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                gridBuyView.ShopModel.SelectItemByIndex(-1);
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      gridSellView tests
        //-------------------------------------------------------------------------------------------------------------------------------------

        //This case tests if the grid buy view displays the correct amount of Items
        [UnityTest]
        public IEnumerator ShopGridSellViewDisplaysCorrectAmountOfItems()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //Now that the scene is loaded and the gridBuyView game object was activated in SetupTests(), we can use GameObject.Find
            //to find the game object we want to test
            GameObject gridItemsPanel = GameObject.Find("GridItemsPanel");

            yield return new WaitForEndOfFrame();//Since we are testing how many items are displayed, we should use WaitForEndOfFrame to wait until the end of the frame,
                                                 //so that the view finished updating and rendering everything 

            int itemCount = gridItemsPanel.transform.childCount;
            Assert.AreEqual(gridSellView.ShopModel.myInventory.GetItemCount(), itemCount, "The generated item count is not equal to shopModel's itemCount");
        }

        [UnityTest]
        public IEnumerator GridSellViewShopGridBuyViewThrowsExceptionsWhenOnLoadInventoryCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                gridSellView.OnShowInvetory(new EventData(EventType.UNITTESTS));
            });
        }

        //This case tests if the buyModel can throw an ArgumentOutOfRangeException when it's asked to select an item by a negative
        //index. Incorrect indexes can be generated from bugs in views or controllers, throwing the correct type of exceptions is
        //better than failing silently for debugging. Your unit tests should cover exception handlings
        [UnityTest]
        public IEnumerator GridSellViewShopModelThrowsExceptionsWhenSelectingNegativeIndex()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                gridSellView.ShopModel.SelectItemByIndex(-1);
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      gridUpgradeView tests
        //-------------------------------------------------------------------------------------------------------------------------------------

        //This case tests if the grid buy view displays the correct amount of Items
        [UnityTest]
        public IEnumerator ShopGridUpgradelViewDisplaysCorrectAmountOfItems()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //Now that the scene is loaded and the gridBuyView game object was activated in SetupTests(), we can use GameObject.Find
            //to find the game object we want to test
            GameObject gridItemsPanel = GameObject.Find("GridItemsPanel");

            yield return new WaitForEndOfFrame();//Since we are testing how many items are displayed, we should use WaitForEndOfFrame to wait until the end of the frame,
                                                 //so that the view finished updating and rendering everything 

            int itemCount = gridItemsPanel.transform.childCount;
            Assert.AreEqual(gridUpgradeView.ShopModel.myInventory.GetItemCount(), itemCount, "The generated item count is not equal to shopModel's itemCount");
        }

        [UnityTest]
        public IEnumerator GridSellViewShopGridUpgradeViewThrowsExceptionsWhenOnLoadInventoryCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                gridUpgradeView.OnShowInvetory(new EventData(EventType.UNITTESTS));
            });
        }

        //This case tests if the buyModel can throw an ArgumentOutOfRangeException when it's asked to select an item by a negative
        //index. Incorrect indexes can be generated from bugs in views or controllers, throwing the correct type of exceptions is
        //better than failing silently for debugging. Your unit tests should cover exception handlings
        [UnityTest]
        public IEnumerator GridUpgradeViewShopModelThrowsExceptionsWhenSelectingNegativeIndex()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                gridUpgradeView.ShopModel.SelectItemByIndex(-1);
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      listBuyView tests
        //-------------------------------------------------------------------------------------------------------------------------------------

        //This case tests if the grid buy view displays the correct amount of Items
        [UnityTest]
        public IEnumerator ListGridBuyViewDisplaysCorrectAmountOfItems()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //Now that the scene is loaded and the gridBuyView game object was activated in SetupTests(), we can use GameObject.Find
            //to find the game object we want to test
            GameObject gridItemsPanel = GameObject.Find("ListItemsPanel");

            yield return new WaitForEndOfFrame();//Since we are testing how many items are displayed, we should use WaitForEndOfFrame to wait until the end of the frame,
                                                 //so that the view finished updating and rendering everything 

            int itemCount = gridItemsPanel.transform.childCount;
            Assert.AreEqual(listBuyView.ShopModel.myInventory.GetItemCount(), itemCount, "The generated item count is not equal to shopModel's itemCount");
        }

        [UnityTest]
        public IEnumerator ShopListBuyViewThrowsExceptionsWhenOnLoadInventoryCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                listBuyView.OnShowInvetory(new EventData(EventType.UNITTESTS));
            });
        }

        //This case tests if the buyModel can throw an ArgumentOutOfRangeException when it's asked to select an item by a negative
        //index. Incorrect indexes can be generated from bugs in views or controllers, throwing the correct type of exceptions is
        //better than failing silently for debugging. Your unit tests should cover exception handlings
        [UnityTest]
        public IEnumerator GridListViewShopModelThrowsExceptionsWhenSelectingNegativeIndex()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                listBuyView.ShopModel.SelectItemByIndex(-1);
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      listSellView tests
        //-------------------------------------------------------------------------------------------------------------------------------------

        //This case tests if the grid buy view displays the correct amount of Items
        [UnityTest]
        public IEnumerator ShopListSellViewDisplaysCorrectAmountOfItems()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //Now that the scene is loaded and the gridBuyView game object was activated in SetupTests(), we can use GameObject.Find
            //to find the game object we want to test
            GameObject gridItemsPanel = GameObject.Find("ListItemsPanel");

            yield return new WaitForEndOfFrame();//Since we are testing how many items are displayed, we should use WaitForEndOfFrame to wait until the end of the frame,
                                                 //so that the view finished updating and rendering everything 

            int itemCount = gridItemsPanel.transform.childCount;
            Assert.AreEqual(listSellView.ShopModel.myInventory.GetItemCount(), itemCount, "The generated item count is not equal to shopModel's itemCount");
        }

        [UnityTest]
        public IEnumerator ListSellViewShopGridBuyViewThrowsExceptionsWhenOnLoadInventoryCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                listSellView.OnShowInvetory(new EventData(EventType.UNITTESTS));
            });
        }

        //This case tests if the buyModel can throw an ArgumentOutOfRangeException when it's asked to select an item by a negative
        //index. Incorrect indexes can be generated from bugs in views or controllers, throwing the correct type of exceptions is
        //better than failing silently for debugging. Your unit tests should cover exception handlings
        [UnityTest]
        public IEnumerator ListSellViewShopModelThrowsExceptionsWhenSelectingNegativeIndex()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                listSellView.ShopModel.SelectItemByIndex(-1);
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //                                                      listUpgradeView tests
        //-------------------------------------------------------------------------------------------------------------------------------------

        //This case tests if the grid buy view displays the correct amount of Items
        [UnityTest]
        public IEnumerator ShopListUpgradelViewDisplaysCorrectAmountOfItems()
        {
            yield return null; //yield return null skips one frame, waits for the Unity scene to load

            //Now that the scene is loaded and the gridBuyView game object was activated in SetupTests(), we can use GameObject.Find
            //to find the game object we want to test
            GameObject gridItemsPanel = GameObject.Find("ListItemsPanel");

            yield return new WaitForEndOfFrame();//Since we are testing how many items are displayed, we should use WaitForEndOfFrame to wait until the end of the frame,
                                                 //so that the view finished updating and rendering everything 

            int itemCount = gridItemsPanel.transform.childCount;
            Assert.AreEqual(listUpgradeView.ShopModel.myInventory.GetItemCount(), itemCount, "The generated item count is not equal to shopModel's itemCount");
        }

        [UnityTest]
        public IEnumerator ListSellViewShopGridUpgradeViewThrowsExceptionsWhenOnLoadInventoryCalledWithWrongEventType()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                listUpgradeView.OnShowInvetory(new EventData(EventType.UNITTESTS));
            });
        }

        //This case tests if the buyModel can throw an ArgumentOutOfRangeException when it's asked to select an item by a negative
        //index. Incorrect indexes can be generated from bugs in views or controllers, throwing the correct type of exceptions is
        //better than failing silently for debugging. Your unit tests should cover exception handlings
        [UnityTest]
        public IEnumerator ListUpgradeViewShopModelThrowsExceptionsWhenSelectingNegativeIndex()
        {
            //yield return null skips one frame, waits for the Unity scene to load and buyModel to be assigned
            yield return null;

            //Creates a delegate that call gridBuyView.ShopModel.SelectItemByIndex(-1), the test runner will run the function, and
            //check if an ArgumentOutOfRangeException is thrown, the unit test would fail if no ArgumentOutOfRangeException
            //was thrown
            Assert.Throws<System.ArgumentOutOfRangeException>(delegate
            {
                listUpgradeView.ShopModel.SelectItemByIndex(-1);
            });
        }
    }
}
