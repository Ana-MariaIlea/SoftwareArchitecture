using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Text;
using TMPro;

public enum CanvasType
{
   Sell,
   Upgrade,
   Buy
}


public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject resourceButtons;
    [SerializeField]
    GameObject TitleAndDescription;
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
    private void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        foreach (CanvasController item in canvasControllerList)
        {
            item.gameObject.SetActive(false);
        }
        SwitchCanvas(CanvasType.Buy);
    }

    public void SwitchCanvas(CanvasType _type)
    {

        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredScreen = canvasControllerList.Find(x => x.type == _type);
        if (desiredScreen != null)
        {
            desiredScreen.gameObject.SetActive(true);
            lastActiveCanvas = desiredScreen;
        }
    }


    public CanvasController GetCurrentCanvas()
    {
        return lastActiveCanvas;
    }
}
