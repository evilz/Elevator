using System.Linq;
using NUnit.Framework;

namespace Elevator.Core.Tests
{
    public class BuildingTest
    {
        private Elevator _elevator;
        private Building _building;

        [SetUp]
        public void Setup()
        {
            _elevator = new Elevator();
            _building = new Building(_elevator);
        }
        
        [Test]
        public void Should_have_no_user_by_default()
        {
            CollectionAssert.IsEmpty(_building.Users);
        }

        [Test]
        public void Should_have_door_closed_by_default()
        {
           Assert.That(_building.IsDoorClosed, Is.True);
        }

        [Test]
        public void Should_be_on_lower_floor_by_default()
        {
            int lowerFloor = -3;

            var building = new Building(_elevator, 10,lowerFloor);

            Assert.That(building.Floor, Is.EqualTo(lowerFloor));
        }
        
        [Test]
        public void Should_have_users_then_users_have_been_added()
        {
            var user = new User();
            _building.AddUser(user);

            CollectionAssert.Contains(_building.Users, user);
        }

        [Test]
        public void Should_not_add_more_than_max_number_of_users()
        {
            var maxUsers = 5;
            var building = new Building(_elevator,maxUsers);

            for (var i = 0; i < 10; i++)
            {
                building.AddUser(new User());
            }
            
            Assert.That(building.Users.Count(), Is.EqualTo(maxUsers));

        }

      
    }
}
