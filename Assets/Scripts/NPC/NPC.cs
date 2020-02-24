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
    private Item FirstWishObject;
    [SerializeField]
    private Item SecondWishObject;
    [SerializeField]
    private Item ThirdWishObject;

    private Item PresentGiven;

    #region GETTER
    public string GetWelcomeText()
    {
        return WelcomeText;
    }
    public string GetFirstWishText()
    {
        return FirstWish;
    }
    public string GetThanksForFirstWishText()
    {
        return ThanksForFirstWish;
    }
    public string GetSecondWishText()
    {
        return SecondWish;
    }
    public string GetThanksForSecondWishText()
    {
        return ThanksForSecondWish;
    }
    public string GetThirdWishText()
    {
        return ThirdWish;
    }
    public string GetThanksForThirdWishText()
    {
        return ThanksForThirdWish;
    }
    public string GetLoveText()
    {
        return LoveText;
    }
    public string GetWrongItemText()
    {
        return WrongItem;
    }


    public Item GetFirstWishObject()
    {
        return FirstWishObject;
    }
    public Item GetSecondWishObject()
    {
        return SecondWishObject;
    }
    public Item GetThirdWishObject()
    {
        return ThirdWishObject;
    }
    #endregion

    public void SetPresent(Item _Present)
    {
        PresentGiven = _Present;
    }
}
