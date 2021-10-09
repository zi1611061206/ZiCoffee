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
    public partial class FormCashier : Form
    {
        public UserModel CurrentUser { get; set; }
        public FormCashier(UserModel user)
        {
            InitializeComponent();
            CurrentUser = user;
            //ChangeAccount(CurrentUser);
        }
    }
}
