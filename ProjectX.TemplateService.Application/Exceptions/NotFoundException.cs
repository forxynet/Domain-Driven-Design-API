namespace ProjectX.Template.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found") {
        }

        public NotFoundException() : base() {
        }

        public NotFoundException(string? message) : base(message) {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
