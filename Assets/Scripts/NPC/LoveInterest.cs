using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveInterest : Interactable
{
    [SerializeField]
    private NPC FemaleLove;

    private Item Present;

    public enum LoveState           
    {
        unknown,
        firstWish,
        secondWish,
        thirdWish,
        love
    }

    [SerializeField]
    private LoveState CurrentLovestate = LoveState.unknown;


    public override void Interact()
    {
        base.Interact();
        Present = Player.GetComponent<PlayerActions>().GetCurrentItem();
        Debug.Log("Start Conversation");
        SwitchLoveState();
    }

    private void SwitchLoveState()        
    {
        switch (CurrentLovestate)
        {
            case (LoveState.unknown):
                GetToKnowTheChar();
                break;

            case (LoveState.firstWish):
                GotPresent(Present, FemaleLove.GetFirstWishObject(), FemaleLove.GetFirstWishText(), FemaleLove.GetThanksForFirstWishText(), LoveState.secondWish);
                break;

            case (LoveState.secondWish):
                GotPresent(Present, FemaleLove.GetSecondWishObject(), FemaleLove.GetSecondWishText(), FemaleLove.GetThanksForSecondWishText(), LoveState.thirdWish);
                break;

            case (LoveState.thirdWish):
                GotPresent(Present, FemaleLove.GetThirdWishObject(), FemaleLove.GetThirdWishText(), FemaleLove.GetThanksForThirdWishText(), LoveState.love);
                break;

            case (LoveState.love):
                LoveText();
                break;
        }
    }


    public void GetToKnowTheChar()
    {
            Debug.Log(FemaleLove.GetWelcomeText());
            CurrentLovestate = LoveState.firstWish;
    }

    private void GotPresent(Item _Present, Item _Wish, string _WishText, string _RightPresentText, LoveState _nextLoveState)
    {
        if (_Present == null)
        {
                Debug.Log("I want to have a " + _WishText);
        }

        else if (_Present == _Wish)
        {
                Debug.Log("Thanks for this " + _RightPresentText);
            Inventory.instance.RemoveItemFromInventory(0);//Inventory.instance.GetCurrentItemIndex());
                CurrentLovestate = _nextLoveState;
        }

        else if (_Present != _Wish)
        {
            WrongPresent();
        }
    }

    private string LoveText()
    {
        return FemaleLove.GetLoveText();
    }

    private string WrongPresent()
    {
        return FemaleLove.GetWrongItemText();
    }
}
