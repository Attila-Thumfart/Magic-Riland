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
    private GameObject HeartParticles;

    private GameObject HeartParticlesInstace;

    [SerializeField]
    private GameObject MessageBox;
    [SerializeField]
    private TMP_Text Message;

    private bool MessageBoxIsActive;

    [SerializeField]
    private float MaxMessageDuration;
    private float MessageBoxTimer;

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
        SwitchLoveState();
    }

    private void Update()
    {
        if (MessageBoxIsActive)
        {
            MessageBoxTimer += Time.deltaTime;

            if(MessageBoxTimer >= MaxMessageDuration)
            {
                MessageBox.SetActive(false);
                MessageBoxIsActive = false;
                MessageBoxTimer = 0;
            }

        }
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
                MessageBoxIsActive = true;
                break;
        }
    }


    public void GetToKnowTheChar()
    {
            Message.text = FemaleLove.GetWelcomeText();
        MessageBox.SetActive(true);
        MessageBoxIsActive = true;
        CurrentLovestate = LoveState.firstWish;
    }

    private void GotPresent(Item _Present, Item _Wish, string _WishText, string _RightPresentText, LoveState _nextLoveState)
    {
        if (_Present == null)
        {
            Message.text = _WishText;
            MessageBox.SetActive(true);
            MessageBoxIsActive = true;
        }

        else if (_Present == _Wish)
        {
            Message.text = _RightPresentText;
            MessageBox.SetActive(true);
            MessageBoxIsActive = true;
            Inventory.instance.RemoveItemFromInventory(Inventory.instance.GetCurrentItemIndex());//Inventory.instance.GetCurrentItemIndex());
                CurrentLovestate = _nextLoveState;
            HeartParticlesInstace = Instantiate(HeartParticles, transform);
            Inventory.instance.ResetCurrentItem();
        }

        else if (_Present != _Wish)
        {
            Message.text = WrongPresent();
            MessageBox.SetActive(true);
            MessageBoxIsActive = true;
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
        MessageBoxIsActive = false;
        MessageBoxTimer = 0;
    }
}
