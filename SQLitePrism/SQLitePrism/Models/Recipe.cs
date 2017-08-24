using Prism.Mvvm;
using SQLite;

namespace SQLitePrism.Models
{
    public class Recipe : BindableBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;

        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}