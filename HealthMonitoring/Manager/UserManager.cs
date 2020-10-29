using HealthMonitoring.Context;
using HealthMonitoring.Models;
using System.Linq;

namespace HealthMonitoring.Manager
{
    public class UserManager
    {
        private HealthMonitorContext _healthMonitorContext;

        public UserManager()
        {
            _healthMonitorContext = new HealthMonitorContext();
        }

        public User FindUserByEmail(string email)
        {
            User user = _healthMonitorContext.User
                        .Where(u => u.Email == email)
                        .FirstOrDefault();
            return user;
        }

        public int AddUser(User user)
        {
            if (FindUserByEmail(user.Email) == null)
            {
                user.Password = PasswordManager.GenerateSHA256String(user.Password);

                _healthMonitorContext.User.Add(user);

                return _healthMonitorContext.SaveChanges();
            }

            return 0;
        }
        public User FindUserByEmailAndPassword(string email,string passwrod)
        {
            passwrod = PasswordManager.GenerateSHA256String(passwrod);
            User user = _healthMonitorContext.User
                .Where(u => u.Email == email && u.Password == passwrod)
                .FirstOrDefault();


            return user;
        }
    }
}