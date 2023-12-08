using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountButton : MonoBehaviour
{
    public int increment = 1;
    [SerializeField] private Player player;

    public void IncreasePlayerAmount()
    {
        player.IncreaseExchangeAmount(increment);
    }

    public void DecreasePlayerAmount()
    {
        player.DecreaseExchangeAmount(increment);
    }

}
