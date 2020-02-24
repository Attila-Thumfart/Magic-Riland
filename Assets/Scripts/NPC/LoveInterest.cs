using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoveInterest : Interactable
{
    [SerializeField]
    private NPC FemaleLove;

    private Item Present;

    [SerializeField]
    private GameObject MessageBox;
    [SerializeField]
    private TMP_Text Message;

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
                Message.text = LoveText();
                MessageBox.SetActive(true);
                break;
        }
    }


    public void GetToKnowTheChar()
    {
            Message.text = FemaleLove.GetWelcomeText();
        MessageBox.SetActive(true);
            CurrentLovestate = LoveState.firstWish;
    }

    private void GotPresent(Item _Present, Item _Wish, string _WishText, string _RightPresentText, LoveState _nextLoveState)
    {
        if (_Present == null)
        {
            Message.text = _WishText;
            MessageBox.SetActive(true);
        }

        else if (_Present == _Wish)
        {
            Message.text = _RightPresentText;
            MessageBox.SetActive(true);
            Inventory.instance.RemoveItemFromInventory(Inventory.instance.GetCurrentItemIndex());//Inventory.instance.GetCurrentItemIndex());
                CurrentLovestate = _nextLoveState;
        }

        else if (_Present != _Wish)
        {
            Message.text = WrongPresent();
            MessageBox.SetActive(true);
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

    public void DisableMessageBox()
    {
        MessageBox.SetActive(false);
    }
}
