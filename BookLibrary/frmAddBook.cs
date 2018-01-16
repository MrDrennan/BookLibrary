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
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var b = new Book();

                b.ISBN = txtIsbn.Text;
                b.Price = Convert.ToDecimal(txtPrice.Text);
                b.Title = txtTitle.Text;

                if (BookDB.Add(b))
                    MessageBox.Show("Book Saved");
                else
                    MessageBox.Show("Error: Count not save the book");
            }
                
        }

        private bool IsValidData()
        {
            
            if (!IsPresent(txtIsbn, "ISBN"))
                return false;
            if (!IsPresent(txtPrice, "Price"))
                return false;
            if (!IsDecimal(txtPrice, "Price"))
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
