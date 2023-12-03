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

    }

    internal void SetCardInfo(Card card)
    {
        Color color = GetColor(card.Suit);
        if (!string.IsNullOrEmpty(card.ResName))
        {
            // Update card image
            cardImage.sprite = Entry.ResMgr.Load<Sprite>(ViewConst.image_card + card.ResName);
        }
        // Update rank text
        rankText.text = GetRankText(card.Rank);
        rankText.color = color;
        // Update suit text and set color
        suitText.text = GetSuitText(card.Suit);
        suitText.color = color;
        // Update name textS
        nameText.text = card.Name;
    }

    private static Color GetColor(Suit suit)
    {
        return suit == Suit.Heart || suit == Suit.Diamond ? Color.red : Color.black;
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
            _ => "",
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
            _ => "",
        };
    }
}