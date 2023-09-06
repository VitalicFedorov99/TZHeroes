using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class UIButton : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<UnityAction> _listActions = new List<UnityAction>();




    public void AddActions(UnityAction unityAction)
    {
        _listActions.Add(unityAction);
    }

    public void ClearActions() => _listActions.Clear();
    public int GetCountActions() => _listActions.Count;
    public List<Sprite> GetSprites() => _sprites;

    public virtual void Setup() { }

    public virtual void UpdateButton(List<Button> buttons, List<Text> text) { }
}
