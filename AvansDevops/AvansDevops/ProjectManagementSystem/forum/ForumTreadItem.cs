namespace AvansDevops.ProjectManagementSystem.forum {
    public class ForumTreadItem {
        public string content { get; set; }
        private User _user;
        private ForumTreadItem? _nextTreadItem;
        public ForumTreadItem(string content, User user) {
            this.content = content;
            this._user = user;
            this._nextTreadItem = null;
        }

        /// <summary>
        /// Get the user that created the tread item
        /// </summary>
        /// <returns>User object</returns>
        public User GetUser() {
            return this._user;
        }

        public ForumTreadItem? nextTreadItem {
            get => _nextTreadItem;
            set {
                if (_nextTreadItem == null) {
                    _nextTreadItem = value;
                } else {
                    _nextTreadItem.nextTreadItem = value;
                }
            }
        }

        public override string ToString() {
            if (_nextTreadItem == null) {
                return _user.name + ": " + content;
            } else {
                return _user.name + ": " + content + "\n" + _nextTreadItem.ToString();
            }
        }
    }
}
