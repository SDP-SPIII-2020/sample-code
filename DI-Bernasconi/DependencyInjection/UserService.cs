namespace DependencyInjection
{
    class UserService
    {
        private INotificationService _notificationService;

        public UserService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void ChangeUsername(User user, string newUsername)
        {
            user.Username = newUsername;
            _notificationService.NotifyUsernameChanged(user);
        }
    }
}
