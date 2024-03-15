namespace Classes
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Dep { get; set; }
        public Employee(int id , string name , Department dep)
        {
            this.Id = id;
            this.Name = name;
            this.Dep = dep;
        }

        //try doing equals
        public override bool Equals(object? obj)
        {
            return Equals(this, obj as Employee);
        }

        public static bool Equals(Employee lhs , Employee rhs)
        {
            if (lhs is null) return rhs is null;
            if (rhs is null) return false;

            return lhs.Id == rhs.Id 
                && lhs.Name == rhs.Name
                && lhs.Dep == rhs.Dep;
        }

        public static bool operator ==(Employee lhs , Employee rhs) =>  Equals(lhs, rhs);

        public static bool operator !=(Employee lhs, Employee rhs) => !Equals(lhs, rhs);

        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + Dep.GetHashCode();
            return hash;
        }

    }

    class Department
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public Department(int id , string location)
        {
            this.Id = id;
            this.Location = location;
        }
        string

        public override int GetHashCode()
        {
            int hash = 13;
            hash = 7 * hash + Id.GetHashCode();
            hash = 7 * hash + Location.GetHashCode();
            return hash;
        }
    }
}