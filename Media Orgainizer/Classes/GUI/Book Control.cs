using Media_Orgainizer.Classes.Data;
using Media_Orgainizer.Classes.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Orgainizer.Classes.GUI
{
    public partial class Book_Control : Control
    {
        public Book_Control(MediaItem mediaItem)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlBook = new Book()
            {
                Media = mediaItem,
                ItemId = Guid.NewGuid()
            };
            Media.AddContent(ControlBook);
        }

        private Book ControlBook;

        public Book_Control(Book b)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlBook = b;
            BookName = b.Name;
        }

        public void InitilazeChildren()
        {
            int leftPos = 0;

            //Control: Name Label
            Controls.Add(lblName);
            lblName.Top = 2;
            leftPos += lblName.Width + 10; //Left Position of Next Control

            //Control: Name Textbox
            Controls.Add(txtName);
            txtName.Left = leftPos;
            int widthOfControlWithoutName = 495 - 100;
            if (Width > 495) txtName.Width = Width - widthOfControlWithoutName;
            leftPos += txtName.Width + 10;

            //Control: Author Label
            Controls.Add(lblAuthor);
            lblAuthor.Top = 2;
            lblAuthor.Left = leftPos;
            leftPos += lblAuthor.Width + 10;

            //Control: Author Textbox
            Controls.Add(txtAuthor);
            txtAuthor.Left = leftPos;
            if (Width > 495) txtAuthor.Width = Width - widthOfControlWithoutName;
            leftPos += txtAuthor.Width + 10;

            //Control: ISBN Label
            Controls.Add(lblISBN);
            lblISBN.Top = 2;
            lblISBN.Left = leftPos;
            leftPos += lblISBN.Width + 10;

            //Control: ISBN Textbox
            Controls.Add(txtISBN);
            txtISBN.Left = leftPos;
            if (Width > 495) txtISBN.Width = Width - widthOfControlWithoutName;
            leftPos += txtISBN.Width + 10;

            ////Control: OK PictureBox
            Controls.Add(pbOK);
            pbOK.Left = leftPos;
            leftPos += pbOK.Width + 10;

            ////Control: Cancel PictureBox
            Controls.Add(pbCancel);
            pbCancel.Left = leftPos;
        }

        public string BookName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
                ControlBook.Name = value;
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            ControlBook.Name = txtName.Text;
            ControlBook.Author = txtAuthor.Text;
            ControlBook.ISBN = txtISBN.Text;
            DataManagment.Save();
            if (SaveSucceded != null) SaveSucceded();
        }

        public new int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                int totalTxtWidth = 495 - 271;
                int newTotalTxtWidth = Width - totalTxtWidth;
                int remainder = newTotalTxtWidth % 3;
                if (Width > 495) txtName.Width = (newTotalTxtWidth / 3);
                if (Width > 495) txtAuthor.Width = newTotalTxtWidth / 3;
                if (Width > 495) txtISBN.Width = newTotalTxtWidth / 3;
                
                int leftPos = 0;
                leftPos += lblName.Width + 10;
                txtName.Left = leftPos;
                leftPos += txtName.Width + 10;
                lblAuthor.Left = leftPos;
                leftPos += lblAuthor.Width + 10;
                txtAuthor.Left = leftPos;
                leftPos += txtAuthor.Width + 10;
                lblISBN.Left = leftPos;
                leftPos += lblISBN.Width + 10;
                txtISBN.Left = leftPos;
                leftPos += txtISBN.Width + 10;
                pbOK.Left = leftPos;
                leftPos += pbOK.Width + 10;
                pbCancel.Left = leftPos;
            }
        }

        public delegate void SaveDelegate();

        public event SaveDelegate SaveSucceded;

        void pb2_Click(object sender, EventArgs e)
        {
            Media.RemoveContent(ControlBook.ItemId);
            DataManagment.Save();
            if (Deleted != null) Deleted();
        }

        public delegate void DeleteDelegate();

        public event DeleteDelegate Deleted;
    }
}
