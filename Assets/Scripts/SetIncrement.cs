using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIncrement : MonoBehaviour
{
    [SerializeField] private AmountButton addButton;
    [SerializeField] private AmountButton subtractButton;

    public void SetTheIncrement(int increment)
    {
        addButton.increment = increment;
        subtractButton.increment = increment;
    }
}
