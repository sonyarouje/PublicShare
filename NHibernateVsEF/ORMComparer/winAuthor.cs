using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ORM.Domain;
namespace ORMComparer
{
    public partial class winAuthor : Form
    {
        public winAuthor()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.GetAndUpdateAuthor(txtAuthorId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAndUpdateAuthor(string idToSearch)
        {
            AuthorServiceClient authorService = new AuthorServiceClient();
            try
            {
                Author author = authorService.GetAuthor(idToSearch);
                author.FirstName = author.FirstName + " NH";
                authorService.Save(author);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                authorService.Close();
            }
        }

    }
}
