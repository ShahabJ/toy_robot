namespace ToyRobot.Library.CustomException
{
    public static class CustomExceptionMessageConstants
    {
        public const string DROP_OFF_TABLE="Robot should not drop off from the table!";
        public const string PLACE_DROP_OFF_TABLE="Robot should not drop off from the table when place robot!";
        public const string NOT_IMPLENMENTED="This function is not implemented yet!";
        public const string INVALID_CMD="Unknown command or command is not registered.";
        public const string INVALID_TARGET_POSITION="Every time before calling execute method in place command, isValidCmd must be called first";
    }
}