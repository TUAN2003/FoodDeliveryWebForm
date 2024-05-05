using System;

namespace BTL_LTW_17.Models
{
    public class User : IComparable<User>
    {
        public string NumberPhone;
        public string Password;
        public string Avatar;
        public string Name;
        public bool Sex;
        public string Address;
        public int Role;

        public User(string numberPhone, string password, string avatar, string name, bool sex)
        {
            NumberPhone = numberPhone;
            Password = password;
            Avatar = avatar;
            Name = name;
            Sex = sex;
        }
        public User(string numberPhone, string password, string avatar, string name, bool sex, string address, int role)
            : this(numberPhone, password, avatar, name, sex)
        {
            Address = address;
            Role = role;
        }
        public User(string numberPhone, string password)
        {
            this.NumberPhone = numberPhone;
            this.Password = password;
        }

        public User(string numberPhone)
        => this.NumberPhone = numberPhone;
        public User() { }

        public int CompareTo(User other)
        {
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return NumberPhone.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj is User)
            {
                User u = (User)obj;
                return u.NumberPhone.Equals(NumberPhone);
            }
            return false;
        }

        public bool EqualsPassword(string password)
        {
            return Password.Equals(password);
        }

        public User Clone()
        {
            return new User(NumberPhone, Password, Avatar, Name, Sex, Address, Role);
        }
    }
}