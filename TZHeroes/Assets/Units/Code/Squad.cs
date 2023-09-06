using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
[System.Serializable]
public class Squad : MonoBehaviour, IPointerClickHandler, IStayInHex
{
    [SerializeField] private int count;
    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private UnitStats stats;
    [SerializeField] private int countButton;


    [SerializeField] private GameEvent eventEndMovement;
    [SerializeField] private GameEvent eventSkipStep;
    [SerializeField] private GameEvent eventSquadMovement;
    [SerializeField] private GameEvent eventPreparationForFight;
    [SerializeField] private GameEvent eventAttack;


    [SerializeField] private ChooseEnemyUnit chooseEnemyUnit;

    private FightComponent fightComponent;
    private Player player;
    private Hex currentHex;
    private List<Hex> hexPath;
    private List<Hex> hexOverview;
    public void OnPointerClick(PointerEventData eventData)
    {
        chooseEnemyUnit.EnemySquad = this;
        eventAttack.Raise();
    }

    public FightComponent GetFightComponent() => fightComponent;
    public Hex GetHex() => currentHex;
    public void SetupFightComponent()
    {
        fightComponent = GetComponent<FightComponent>();
        fightComponent.Setup(stats, count);
    }

    public void PutOnHex(Hex hex)
    {
        transform.position = hex.transform.position;
        hex.ObjectEnterHex(this);
        currentHex = hex;
    }

    public void Setup(Player player)
    {
        this.player = player;
    }

    public void Move()
    {
        hexOverview = WavedAlgorithm.SearchHexesWithoutNotWalkalbe(currentHex, (int)stats.Movement);
        foreach (var hex in hexOverview)
        {
            hex.OnColorize(Color.red);
        }
        int rand = Random.Range(0, hexOverview.Count);
        eventSquadMovement.Raise();
    }

    public bool CheckHex(Hex hex)
    {
        hexOverview = WavedAlgorithm.SearchHexesWithoutNotWalkalbe(currentHex, (int)stats.Movement);
        if (hexOverview.Contains(hex))
            return true;
        return false;
    }

    public void Move(Hex hex)
    {
        eventEndMovement.Raise();
        AStar.FindPath(currentHex, hex, out hexPath);
        StartCoroutine(CoroutineMove());
    }


    public void PreparationForFight()
    {
        eventPreparationForFight.Raise();
    }

    public void SkipStep()
    {
        eventSkipStep.Raise();
    }

    public int GetCountButton() => countButton;
    public List<UnityAction> GetUnityActions()
    {
        List<UnityAction> newList = new List<UnityAction>();
        newList.Add(Move);
        newList.Add(SkipStep);
        newList.Add(PreparationForFight);
        return newList;
    }
    private IEnumerator CoroutineMove()
    {

        currentHex.ObjectExitHex();
        var startHex = hexPath[0];

        for (int i = 0; i < hexPath.Count; i++)
        {
            while (Vector2.Distance(transform.position, hexPath[i].transform.position) > 0.2f)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, hexPath[i].transform.position, 2 * Time.deltaTime);
                yield return null;
            }
        }
        PutOnHex(hexPath[hexPath.Count - 1]);
    }

    private void Start()
    {
        SetupFightComponent();
    }
}
