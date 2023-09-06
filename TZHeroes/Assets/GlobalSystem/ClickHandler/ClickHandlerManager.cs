using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerManager : MonoBehaviour
{
    private ClickHandler currentClickHandler;
    [SerializeField] private ClickHandlerStateMove clickHandlerStateMove;
    [SerializeField] private ClickHandlerIdle idle;
    [SerializeField] private ClickHandlerStateAttack attack;

    private void Start()
    {
        currentClickHandler = idle;
    }


    public void ChangeClickHandler()
    {
        currentClickHandler = clickHandlerStateMove;
    }


    public void ChooseIdleHandler()
    {
        currentClickHandler = idle;
    }

    public void ChooseAttackHandler() 
    {
        currentClickHandler = attack;
    }
    public void Execute()
    {
        currentClickHandler.Setup();
        currentClickHandler.Execute();
    }

}
