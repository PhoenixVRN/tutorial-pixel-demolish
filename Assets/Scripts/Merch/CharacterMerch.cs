using TMPro;
using UnityEngine;

public class CharacterMerch : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textState;
    public TextMeshProUGUI textNumber;

    public int coin;
    public BehaviorStrategy state;
    public int number;

    public void init()
    {
        textCoin.text = coin.ToString();
        textState.text = state.ToString();
        textNumber.text = number.ToString();
    }
    void Update()
    {
    }
}