using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Bool")]
public class BoolCondition : Condition<bool>
{

    protected override void CheckType()
    {
        var cache = VarToCompare;
        if (!(VarToCompare is BoolVar))
        {
            Debug.Log("You must assign a BoolVar.");
            VarToCompare = cache;
        }
    }

}
