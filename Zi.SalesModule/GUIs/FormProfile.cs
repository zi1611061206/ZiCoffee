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
    public partial class FormProfile : Form
    {
        #region Attributes
        public UserModel CurrentUser { get; set; }
        public RoleModel CurrentRole { get; set; }
        #endregion
        public FormProfile(UserModel currentUser, RoleModel currentRole)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            CurrentRole = currentRole;
        }
    }
}
