using Assets.Scripts.Game.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    [SerializeField] Image cardImage;
    [SerializeField] TextMeshProUGUI rankText;
    [SerializeField] TextMeshProUGUI suitText;
    [SerializeField] TextMeshProUGUI nameText;

    // Set card information method
    public void SetCardInfo(Sprite cardSprite, int rank, Suit suit, string cardName)
    {
        // Update card image
        if (cardImage != null)
        {
            cardImage.sprite = cardSprite;
        }

        // Update rank text
        if (rankText != null)
        {
            rankText.text = GetRankText(rank);
            rankText.color = (suit == Suit.Heart || suit == Suit.Diamond) ? Color.red : Color.black;
        }

        // Update suit text and set color
        if (suitText != null)
        {
            suitText.text = GetSuitText(suit);

            // Set color based on suit
            suitText.color = (suit == Suit.Heart || suit == Suit.Diamond) ? Color.red : Color.black;
        }

        // Update name text
        if (nameText != null)
        {
            nameText.text = cardName;
        }
    }

    internal void SetCardInfo(Card card)
    {
        Sprite cardSprite = Entry.ResMgr.Load<Sprite>(ViewConst.image_card + card.ResName);
        SetCardInfo(cardSprite, card.Rank, card.Suit, card.Name);
    }

    private string GetRankText(int rank)
    {
        return rank switch
        {
            1 => "A",
            <= 10 => rank.ToString(),
            11 => "J",
            12 => "Q",
            13 => "K",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    private string GetSuitText(Suit suit)
    {
        return suit switch
        {
            Suit.None => "",
            Suit.Diamond => "♦",
            Suit.Heart => "♥",
            Suit.Club => "♣",
            Suit.Spade => "♠",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}