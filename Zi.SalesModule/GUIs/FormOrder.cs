using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DTOs;

namespace Zi.SalesModule.GUIs
{
    public partial class FormOrder : Form
    {
        #region Attributes
        public TableModel CurrentTable { get; set; }
        public UserModel CurrentUser { get; set; }
        #endregion

        public FormOrder(TableModel currentTable, UserModel currentUser)
        {
            InitializeComponent();
            CurrentTable = currentTable;
            CurrentUser = currentUser;
        }
    }
}
