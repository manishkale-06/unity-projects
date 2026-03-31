using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class SetTurn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ActionBasedContinuousTurnProvider continuosTurn;
    public ActionBasedSnapTurnProvider snapTurn;


    public void SetType(int index)
    {
        if(index == 0)
        {
            snapTurn.enabled = false;
            continuosTurn.enabled = true;
        }
        else if(index == 1)
        {
            snapTurn.enabled = true;
            continuosTurn.enabled = false;
        }
    }
}
