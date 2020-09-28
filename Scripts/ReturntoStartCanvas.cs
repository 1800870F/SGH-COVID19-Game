using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ReturntoStartCanvas : MonoBehaviour
{
    public GameObject startMenu;
    public Canvas questionCanvas;
    public Canvas completeMenu;
    public void returntoStart()
    {
        startMenu.SetActive(true);
        completeMenu.enabled = false;
        questionCanvas.enabled = true;
    }
}
