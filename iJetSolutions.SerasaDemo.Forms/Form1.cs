using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iJetSolutions.SerasaDemo.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListarProdutos_Click(object sender, EventArgs e)
        {

            var service = new br.org.spc.treina.consultaWebService();
            service.Credentials = gerarCredencial("398504", "27102017");
            var list = service.listarProdutos().ToList();
        }

        private CredentialCache gerarCredencial(string usuario, string senha)
        {
            string url = @"https://treina.spc.org.br/spc/remoting/ws/consulta/consultaWebService?wsdl";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(usuario, senha));
            return credentialCache;
        }
    }
}
