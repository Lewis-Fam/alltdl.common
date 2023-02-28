namespace alltdl.Constants
{
    [Serializable]
    public enum ConditionComparison
    {
        Equals,

        NotEquals,

        GreaterThan,

        GreaterThanOrEqualTo,

        LessThan,

        LessThanOrEqualTo
    }

    [Serializable]
    public enum ConditionType
    {
        None,

        VariableValue
    }

    [Serializable]
    public enum DynamicVariableType
    {
        None,

        Registry
    }

    [Serializable]
    public enum VariableDataType
    {
        None,

        Boolean,

        String,

        Integer,

        FloatingPoint,
    }

    [Serializable]
    public enum VariableKind
    {
        None,

        Static,

        Dynamic
    }
}