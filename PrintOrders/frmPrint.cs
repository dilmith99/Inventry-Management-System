using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintOrders
{
    public partial class frmPrint : Form
    {
        //private BindingSource OrderDetailBindingSource;

        Orders _orders;
        List<OrderDetail> _list;
        public frmPrint(Orders orders, List<OrderDetail> list)
        {
            InitializeComponent();
            _orders = orders;
            _list = list;
        }
       

        private void frmPrint_Load(object sender, EventArgs e)
        {

           

            //Init data source
        
            OrderDetailBindingSource.DataSource = _list;
           
     
            //Set parameter for your report
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pOrderID",_orders.OrderID.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pOrderDate",_orders.OrderDate.ToString("MM/dd/yyyy")),
                new Microsoft.Reporting.WinForms.ReportParameter("pContactName",_orders.ContactName),
                new Microsoft.Reporting.WinForms.ReportParameter("pPostalCode",_orders.PostalCode),
                new Microsoft.Reporting.WinForms.ReportParameter("pAddress",_orders.Address),
                new Microsoft.Reporting.WinForms.ReportParameter("pCity",_orders.City),
                new Microsoft.Reporting.WinForms.ReportParameter("pPhone",_orders.Phone)
            };

            
            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();

        }
    }
}