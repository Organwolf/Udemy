using System;
namespace AccessModifiers
{
    public class Person
    {
        private DateTime _birthdate;

        public void SetBirthDate(DateTime birthdate)
        {
            _birthdate = birthdate;
        }

        public DateTime GetBirthdate()
        {
            return _birthdate;
        }

        public Person()
        {
        }
    }
}
