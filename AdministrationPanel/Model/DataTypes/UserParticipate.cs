namespace Model.DataTypes
{
    public enum UserParticipate
    {
        No,
        Yes,
        NotDefined
    }

    public static class UserParticipateExtension
    {
        public static bool? ToBool(this UserParticipate enumVal)
        {
            switch (enumVal)
            {
                case UserParticipate.No:
                    return false;
                case UserParticipate.Yes:
                    return true;
            }
            return null;
        }
    }
}