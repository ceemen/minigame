using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollReader : MonoBehaviour
{

    Rigidbody parentRb;
    DiceRoll diceRollParent;
    int valueRolled;

    private void Awake()
    {
        parentRb = gameObject.GetComponentInParent<Rigidbody>();
        diceRollParent = gameObject.GetComponentInParent<DiceRoll>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (parentRb.IsSleeping()
    && other.gameObject.tag == "RollReader" && diceRollParent.beenRolled)
        {
            switch (gameObject.name)
            {
                case "1Roll":
                    ReturnValue(1);
                    break;
                case "2Roll":
                    ReturnValue(2);
                    break;
                case "3Roll":
                    ReturnValue(3);
                    break;
                case "4Roll":
                    ReturnValue(4);
                    break;
                case "5Roll":
                    ReturnValue(5);
                    break;
                case "6Roll":
                    ReturnValue(6);
                    break;
                default:
                    break;
            }
            diceRollParent.beenRolled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    int ReturnValue(int value)
    {
        valueRolled = value;
        print(valueRolled);
        return valueRolled;
    }

    int GetRolledValue()
    {
        return valueRolled;
    }
}
