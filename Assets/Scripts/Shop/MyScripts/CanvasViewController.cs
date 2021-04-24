using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasViewController : MonoBehaviour
{

    [SerializeField]
    private GameObject gridBuyView;
    [SerializeField]
    private GameObject listBuyView;
    [SerializeField]
    private GameObject gridSellView;
    [SerializeField]
    private GameObject listSellView;
    [SerializeField]
    private GameObject gridUpgradeView;
    [SerializeField]
    private GameObject listUpgradeView;

    // Start is called before the first frame update

    private void Start()
    {
        Invoke("OnStartGame", 1f);
    }
    public void OnStartGame()
    {
        listBuyView.SetActive(false);
        gridSellView.SetActive(false);
        listSellView.SetActive(false);
        gridUpgradeView.SetActive(false);
        listUpgradeView.SetActive(false);
    }

}
