using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> allButtons;

    [SerializeField] private List<Button> activeButtons;

    [SerializeField] private ChooseUnitSO chooseUnit;

    private void Start()
    {
        activeButtons = new List<Button>();
    }

    public void UpdateButton() 
    {
        OffButton();
        for(int i=0;i< chooseUnit.countButton; i++) 
        {
            activeButtons.Add(allButtons[i]);
            activeButtons[i].gameObject.SetActive(true);
            if(i<chooseUnit.actions.Count)
            activeButtons[i].onClick.AddListener(chooseUnit.actions[i]);
        }
    }

    private void OffButton() 
    {
        foreach(var but in allButtons) 
        {
            but.gameObject.SetActive(false);
            but.onClick.RemoveAllListeners();
        }
        activeButtons.Clear();
    }
}
