using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Hex : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<Hex> _neighbourArray = new List<Hex>();

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private GameEvent eventCancelAttack;
    [SerializeField] private ChooseZoneAction chooseZone;
    [SerializeField] private ChooseHex chooseHex;



    [SerializeField] private HexWalkable hexWalkable;

    private Color currentColor;
    public Vector2Int PositionInGrid { get; set; }
    public List<Hex> NeighbourArray { get => _neighbourArray; set => _neighbourArray = value; }


    private void Start()
    {
        currentColor = sprite.color;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(PositionInGrid.x + " -" + PositionInGrid.y);
        chooseHex.CurrentPosition = PositionInGrid;
        chooseHex.currentHex = this;
        gameEvent.Raise();
        eventCancelAttack.Raise();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sprite.color = Color.gray;
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sprite.color = currentColor;
    }

    public void ObjectEnterHex(IStayInHex obj)
    {
        hexWalkable.ObjectEnterHex(obj);
    }

    public void ObjectExitHex()
    {
        hexWalkable.ObjectExitHex();
    }

    public bool CheckHexWalkable() => hexWalkable.CheckWalkable();
    

    public void OnColorize()
    {
        sprite.color = Color.gray;
    }

    public void OnColorize(Color color)
    {
        sprite.color = color;
    }

    public void OffColorize()
    {
        sprite.color = currentColor;
    }


}
