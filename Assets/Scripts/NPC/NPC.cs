using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
    [SerializeField]
    private string NPCName;
    [SerializeField]
    private string WelcomeText;
    [SerializeField]
    private string FirstWish;
    [SerializeField]
    private string ThanksForFirstWish;
    [SerializeField]
    private string SecondWish;
    [SerializeField]
    private string ThanksForSecondWish;
    [SerializeField]
    private string ThirdWish;
    [SerializeField]
    private string ThanksForThirdWish;
    [SerializeField]
    private string LoveText;
    [SerializeField]
    private string WrongItem;

    [SerializeField]
    private GameObject NPCMesh;
    [SerializeField]
    private GameObject Wish1;
    [SerializeField]
    private GameObject Wish2;
    [SerializeField]
    private GameObject Wish3;

    private GameObject PresentGiven;


    public void SetPresent(GameObject _Present)
    {
        PresentGiven = _Present;
    }
}
