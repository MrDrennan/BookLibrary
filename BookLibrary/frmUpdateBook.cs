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
    public partial class frmUpdateBook : Form
    {
        private Book currBook;

        public frmUpdateBook(Book b)
        {
            InitializeComponent();
            currBook = b;
        }

        private void frmUpdateBook_Load(object sender, EventArgs e)
        {
            txtIsbn.Text = currBook.ISBN;
            txtPrice.Text = currBook.Price.ToString("c");
            txtTitle.Text = currBook.Title;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                Book updatedBook = new Book();

                updatedBook.ISBN = txtIsbn.Text;
                updatedBook.Price = Convert.ToDecimal(txtPrice.Text.Replace("$", string.Empty));
                updatedBook.Title = txtTitle.Text;


                if (BookDB.Update(updatedBook))
                {
                    MessageBox.Show("Book updated!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Book not updated!");
                }
            }
                
        }

        private bool IsValidData()
        {

            if (!IsPresent(txtPrice, "Price"))
                return false;
            if (!IsPresent(txtTitle, "Title"))
                return false;

            return true;
        }
        private bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == string.Empty)
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        private bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
    }
}
