using UnityEngine;

public abstract class Condition<T> : Condition where T : System.IComparable<T>
{

    [Header("Variable to compare")]
    [Tooltip("The Var to compare to the indicated value.")]
    public Var<T> VarToCompare;

    [Header("Operator to compare with")]
    [Tooltip("The equality operator used to compare the VarToCompare's value and the ValueToCompare.")]
    public EqualityOp EqualityOp;

    [Header("Values to compare to")]
    [Tooltip("The Value to compare to the Var's value.")]
    public T ValueToCompare;
    [Tooltip("Another Var's value to compare with the VarToCompare. Overrides ValueToCompare.")]
    public Var<T> VarValueToCompare;

    [Header("Other")]
    [Tooltip("If true, the comparison result is reversed.")]
    public bool ReverseComparison = false;

    public bool Compare()
    {
        return CompareValue(VarValueToCompare ? VarValueToCompare.Value : ValueToCompare);
    }

    bool CompareValue(T value)
    {
        bool comparison;

        switch (EqualityOp)
        {
            case EqualityOp.NotEqualTo:
                comparison = (VarToCompare.Value.CompareTo(value) != 0);
                break;
            case EqualityOp.EqualTo:
                comparison = (VarToCompare.Value.CompareTo(value) == 0);
                break;

            case EqualityOp.LessThan:
                comparison = (VarToCompare.Value.CompareTo(value) < 0);
                break;
            case EqualityOp.GreaterThan:
                comparison = (VarToCompare.Value.CompareTo(value) > 0);
                break;

            case EqualityOp.LessThanOrEqualTo:
                comparison = (VarToCompare.Value.CompareTo(value) <= 0);
                break;
            case EqualityOp.GreaterThanOrEqualTo:
                comparison = (VarToCompare.Value.CompareTo(value) >= 0);
                break;

            default:
                return false;
        }

        if (ReverseComparison)
            comparison = !comparison;

        return comparison;
    }

    #region Editor
#if UNITY_EDITOR

    /// <summary>
    /// Makes sure you assign the right type of Var.
    /// </summary>
    private void OnValidate()
    {
        CheckType();
        CheckEqualityOp();
    }

    /// <summary>
    /// Checks if the VarToCompare's type matches that of the derived class.
    /// </summary>
    protected abstract void CheckType();

    void CheckEqualityOp()
    {
        if (typeof(T) == typeof(bool))
        {
            if (EqualityOp > EqualityOp.EqualTo)
            {
                Debug.LogWarning("Can only use EqualTo or NotEqualTo for bools.");
                EqualityOp = EqualityOp.NotEqualTo;
            }
        }
    }

#endif
    #endregion

}

/// <summary>
/// Needed to keep the type class truly generic in fields, 
/// i.e. you must declare a type for a Condition[] array without this inheritance
/// and we don't want that.
/// </summary>
public class Condition : ScriptableObject { }
