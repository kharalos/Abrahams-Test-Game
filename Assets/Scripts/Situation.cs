using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation : InteractableObject
{
    public int situationID;
    public override void Interaction()
    {
        FindObjectOfType<Knife>().ChangeSituation(situationID);
    }

}
