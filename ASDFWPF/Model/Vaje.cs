using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ASDFWPF
{


    public class Vaje
    {
        public int Id { get; set; }
        public ObservableCollection<Vsebina> vsebina { get; set; }
        public DateTime? zadnjicReseno { get; set; }
        public bool reseno { get; set; }
        private int _napake;
        public int napake 
        { 
            get { return this._napake; }
            set { _napake=value; }
        }
        public int porabljencas { get; set; }
        public ImageSource slika { get; set; }
        public bool test { get; set; }
        public string[] crke { get; set; }
        private TipkanjeDataGroup _group;
        public TipkanjeDataGroup Group
        {
            get { return this._group; }
            set { _group=value; }
        }
    }
    public class Rezultati
    {
        public int Id { get; set; }
        private int _napake;
        public int napake
        {
            get { return this._napake; }
            set { _napake = value; }
        }
        public decimal porabljencas { get; set; }
        public DateTime? zadnjicReseno { get; set; }
        private int _udarci;
        public int udarci
        {
            get { return this._udarci; }
            set { _udarci = value; }
        }
    }
    public class Vsebina
    {
        public int vrstica { get; set; }
        public string tekst { get; set; }
    }
    public class TipkanjeDataGroup:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _Id = string.Empty;
        public string Id
        {
            get { return this._Id; }
            set { _Id = value; }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { _title = value; }
        }

        private string _shortTitle = string.Empty;
        public string ShortTitle
        {
            get { return this._shortTitle; }
            set { _shortTitle = value; }
        }

        private ImageSource _image = null;
        private String _imagePath = null;

        public Uri ImagePath
        {
            get
            {
                return new Uri(_baseUri, this._imagePath);
            }
        }

        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(_baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                _image = value;
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }

        public string GetImageUri()
        {
            return _imagePath;
        }
        private ObservableCollection<Vaje> _items = new ObservableCollection<Vaje>();
        public ObservableCollection<Vaje> Items
        {
            get { return this._items; }
        }

        public IEnumerable<Vaje> TopItems
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed
            get { return this._items.Take(12); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { _description = value; }
        }

        private ImageSource _groupImage;
        private string _groupImagePath;
        static Uri _baseUri = new Uri("ms-appx:///");

     

        public ImageSource GroupImage
        {
            get
            {
                if (this._groupImage == null && this._groupImagePath != null)
                {
                    this._groupImage = new BitmapImage(new Uri(_baseUri, this._groupImagePath));
                }
                return this._groupImage;
            }
            set
            {
                this._groupImagePath = null;
                _groupImage = value;
            }
        }
        public void SetGroupImage(String path)
        {
            this._groupImage = null;
            this._groupImagePath = path;
            this.OnPropertyChanged("GroupImage");
        }
    }
}