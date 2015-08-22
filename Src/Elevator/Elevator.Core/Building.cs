using System.Collections.Generic;

namespace Elevator.Core
{
    public class Building
    {
        private int _maxUsers;
        private readonly Elevator _elevator;
        private readonly List<User> _users = new List<User>();
        private int _lowerFloor;

       

        public Building(Elevator elevator, int maxUsers = 10, int lowerFloor = default(int))
        {
            _elevator = elevator;
            _maxUsers = maxUsers;
            IsDoorClosed = true;
            _lowerFloor = lowerFloor;
            Floor = _lowerFloor;
        }

        public IEnumerable<User> Users => _users;

        public bool IsDoorClosed { get; private set; }

        public void AddUser(User user)
        {
            if (_users.Count >= _maxUsers) return;
            _users.Add(user);
        }

        public int Floor { get; private set;}
    }
}