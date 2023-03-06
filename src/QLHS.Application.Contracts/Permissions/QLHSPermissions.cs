namespace QLHS.Permissions;

public static class QLHSPermissions
{
    public const string GroupName = "QLHS";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Subject
    {
        public const string Default = GroupName + ".Subject";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
