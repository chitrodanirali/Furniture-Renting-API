namespace Domain.Shared
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
        public static Error AlreadyExists(string entity, string name) => new Error($"Error.AlreadyExists.{name}", $"The {entity} '{name}' already exists.");

        public static Error UserNamePasswordError() => new Error($"Error.UserNamePasswordError", $"The username or password supplied was incorrect.");

        public static Error AccessFailedCount() => new Error($"Error.AccessFailedCount", $"Too many failed login attempts, account disabled.  Contact an administrator.");
        public static Error InternalServerError(string ex) => new Error($"InternalServerError", $"exception : '{ex}'");
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }

        public string Message { get; }

        public static implicit operator string(Error error) => error.Code;

        public static bool operator ==(Error? a, Error? b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Error? a, Error? b) => !(a == b);

        public virtual bool Equals(Error? other)
        {
            if (other is null)
            {
                return false;
            }

            return Code == other.Code && Message == other.Message;
        }

        public override bool Equals(object? obj) => obj is Error error && Equals(error);

        public override int GetHashCode() => HashCode.Combine(Code, Message);

        public override string ToString() => Code;
    }
}
