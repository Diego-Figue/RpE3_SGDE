using appE3_SGDE.Datoss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace appE3_SGDE.Vistaa
{
    public partial class frmRecuperarContraseña : Form
    {
        public frmRecuperarContraseña()
        {
            InitializeComponent();
        }


        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {

            try
            {

                if (txtCorreo.Text != "")
                {


                    string msg = "Error al enviar este correo, verifique su correo o intente más tardes";
                    string fromGmail = "aceroa575@gmail.com";
                    string displayName = "sgde";


                    MailMessage mailGmail = new MailMessage();
                    mailGmail.From = new MailAddress(fromGmail, displayName);
                    mailGmail.To.Add(new MailAddress(txtCorreo.Text));
                    mailGmail.Subject = ("Recuperar contraseña, sgde");
                    mailGmail.IsBodyHtml = true;
                    mailGmail.Body = "Hola! buen dia, Usted solicito recuperar su contraseña:   Su contraseña es: sgde123";
                    mailGmail.Priority = MailPriority.Normal;


                    SmtpClient smtpGmail = new SmtpClient("smtp.gmail.com", 587);
                    smtpGmail.Credentials = new NetworkCredential(fromGmail, "1002438364");
                    smtpGmail.EnableSsl = true;
                    smtpGmail.Send(mailGmail);






                    if (txtCorreo.Text == "grupo3sgde2021@gmail.com")
                    {

                        MessageBox.Show("!Contraseña enviada correctamente¡", "Envio de correo satisfactorio", MessageBoxButtons.OK);

                    }
                    else
                    {
                        MessageBox.Show("Correo no encontrado", "Error al restaurar la contraseña", MessageBoxButtons.OK);
                    }

                    try
                    {
                        smtpGmail.Send(mailGmail);
                    }
                    catch (Exception ex)
                    {

                        Console.Write(ex);
                    }

                    txtCorreo.Text = "";
                    txtUsuario.Text = "";


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Correo no encontrado", "Error al restaurar la contraseña", MessageBoxButtons.OK);

            }

        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }



    }
}






