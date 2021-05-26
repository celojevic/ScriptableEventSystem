using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Events/Var Event")]
public class VarEvent : ScriptableEvent
{

    /// <summary>
    /// The variable to change.
    /// </summary>
    public Var Var;

    /// <summary>
    /// How the variable is changed.
    /// </summary>
    public VarChange VarChange;

    private void OnValidate()
    {
        if ((Var is IntVar && !(VarChange is IntVarChange))
            || (Var is BoolVar && !(VarChange is BoolVarChange))
            || (Var is StringVar && !(VarChange is StringVarChange)))
        {
            Debug.LogError("Var and VarChange do not match up on VarEvent: " + name);
        }
    }

    public override void Parse()
    {
        if (Var is IntVar intVar)
        {
            ParseIntVar(intVar);
        }
        else if (Var is BoolVar boolVar)
        {
            ParseBoolVar(boolVar);
        }
        else if (Var is StringVar stringVar)
        {
            ParseStringVar(stringVar);
        }
    }

    void ParseIntVar(IntVar intVar)
    {
        IntVarChange intVarChange = VarChange as IntVarChange;
        switch (intVarChange.MathOp)
        {
            case MathOp.Add:
                intVar.Value += intVarChange.Val;
                break;

            case MathOp.Sub:
                intVar.Value -= intVarChange.Val;
                break;

            case MathOp.Div:
                intVar.Value *= intVarChange.Val;
                break;

            case MathOp.Mul:
                intVar.Value /= intVarChange.Val;
                break;
        }
    }

    void ParseBoolVar(BoolVar boolVar)
    {
        BoolVarChange change = VarChange as BoolVarChange;
        switch (change.BoolOp)
        {
            case BoolOp.True:
                boolVar.Value = true;
                break;

            case BoolOp.False:
                boolVar.Value = false;
                break;

            case BoolOp.Switch:
                boolVar.Value = !boolVar.Value;
                break;
        }
    }

    void ParseStringVar(StringVar stringVar)
    {
        StringVarChange change = VarChange as StringVarChange;
        switch (change.StringOp)
        {
            case StringOp.Change:
                stringVar.Value = change.NewValue;
                break;

            case StringOp.Append:
                stringVar.Value += change.NewValue;
                break;

            case StringOp.Remove:
                if (stringVar.Value.Contains(change.NewValue))
                    stringVar.Value = stringVar.Value.Replace(change.NewValue, "");
                break;
        }
    }

}