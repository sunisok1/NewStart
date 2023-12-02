using UnityEngine;

public enum SexType
{
    Male,
    Female,
    Other
}

public enum CountryType
{
    Qun,
    Wei,
    Shu,
    Wu
}

public struct PlayerData
{
    public SexType Sex;
    public CountryType Country;
    public int MaxHp;
    public int Hp;
    public bool IsLinked;
}

//public struct PlayerData
//{
//    public ObservableValue<SexType> Sex;
//    public ObservableValue<CountryType> Country;
//    public ObservableValue<int> MaxHp;
//    public ObservableValue<int> Hp;
//    public ObservableValue<bool> IsLinked;

//    // Constructor to initialize ObservableValue fields
//    public PlayerData(SexType sex, CountryType country, int maxHp, int hp, bool isLinked)
//    {
//        Sex = new ObservableValue<SexType> { Value = sex };
//        Country = new ObservableValue<CountryType> { Value = country };
//        MaxHp = new ObservableValue<int> { Value = maxHp };
//        Hp = new ObservableValue<int> { Value = hp };
//        IsLinked = new ObservableValue<bool> { Value = isLinked };
//    }
//}

public class Player : MonoBehaviour
{
    public PlayerData data;
}