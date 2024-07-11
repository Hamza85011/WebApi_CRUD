

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UserModel
    {
        internal string FirstName;

        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
