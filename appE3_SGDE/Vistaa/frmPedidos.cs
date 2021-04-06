using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appE3_SGDE.Vistaa
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            //initializa
            Cef.Initialize(settings);
            txtDireccionUrl.Text = "https://web.whatsapp.com";
            chrome = new ChromiumWebBrowser(txtDireccionUrl.Text);
            this.panelNavegador.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChange;

        }

        private void Chrome_AddressChange(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                txtDireccionUrl.Text = e.Address;
            }));
        }

        private void frmPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void btnIr_Click_1(object sender, EventArgs e)
        {
            chrome.Load(txtDireccionUrl.Text);
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            chrome.Refresh();
        }

        private void btnAdelante_Click_1(object sender, EventArgs e)
        {
            if (chrome.CanGoForward)
                chrome.Forward();
        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            if (chrome.CanGoBack)
                chrome.Back();
        }
    }
}