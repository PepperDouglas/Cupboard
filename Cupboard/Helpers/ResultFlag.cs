namespace Cupboard.Helpers
{
    //The purpose of this class is to not throw exceptions when the application
    //encounters errors that could be interpreted as part of a common use case,
    //that are not neccessarily "unexpected"
    public class ResultFlag
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResultFlag(bool success, string message) {
            Success = success;
            Message = message;
        }

        public ResultFlag(bool success) {
            Success = success;
        }

        public ResultFlag()
        {
            
        }
    }
}
