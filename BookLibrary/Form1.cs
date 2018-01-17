using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddBook addBook = new frmAddBook();
            addBook.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboBooks.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a book");
            }
            else
            {
                Book b = cboBooks.SelectedItem as Book;

                frmUpdateBook updateForm = new frmUpdateBook(b);

                updateForm.ShowDialog();
            }
            
        }

        public void PopulateBooksCombobox()
        {
            cboBooks.Items.Clear();

            List<Book> bookList = BookDB.GetAllBooks();

            foreach (Book b in bookList)
            {
                cboBooks.Items.Add(b);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateBooksCombobox();
        }

        private void cboBooks_DropDown(object sender, EventArgs e)
        {
            PopulateBooksCombobox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboBooks.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a book");
                return;
            }


            Book selectedBook = (Book)cboBooks.SelectedItem;

            if (BookDB.Delete(selectedBook))
            {
                MessageBox.Show("Book Deleted!");
                PopulateBooksCombobox();
            }
            else
            {
                MessageBox.Show("No Book was deleted");
            }
        }
    }
}
