namespace AvansDevops.ProjectManagementSystem {
    public class User {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public User(string name, string email, string phoneNumber ) {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}
