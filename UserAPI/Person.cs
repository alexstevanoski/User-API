namespace UserAPI
{
    public class Person
    {
        public string name { get; set; }
        public string email { get; set; }
        public int id { get; set; }
        public string password { get; set; }


        public Person()
        {

        }

        public Person(string name, string email, int id, string password)
        {
            this.name = name;
            this.email = email;
            this.id = id;
            this.password = password;
        }
    }
}
